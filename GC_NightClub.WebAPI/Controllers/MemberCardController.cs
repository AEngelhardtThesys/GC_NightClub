using GC_NightClub.WebAPI.Domain;
using GC_NightClub.WebAPI.Models;
using GC_NightClub.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GC_NightClub.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberCardController : ControllerBase
    {
        private readonly IEntityService<IdentityCard, Guid> _identityCardService;
        private readonly IEntityService<MemberCard, string> _memberCardService;

        public MemberCardController(
            IEntityService<IdentityCard, Guid> identityCardService,
            IEntityService<MemberCard, string> memberCardService)
        {
            _identityCardService = identityCardService;
            _memberCardService = memberCardService;
        }

        [HttpGet("isblacklisted/{cardNumber}")]
        public IActionResult Get(string cardNumber)
        {
            try
            {
                var mc = _memberCardService.Get(cardNumber);
                return Ok(new
                {
                    CardNumber = mc.Id,
                    IsBlacklisted = mc.BlacklistedUntilDate != null
                        && (DateTime)mc.BlacklistedUntilDate >= DateTime.Today
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultModel(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Register(CreateCardModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.PhoneNumber))
            {
                var validationMessage = "Please provide at least the email address or the phone number.";
                ModelState.AddModelError(nameof(model.Email), validationMessage);
                ModelState.AddModelError(nameof(model.PhoneNumber), validationMessage);
            }

            if (_memberCardService.GetAll().Any(mc => mc.Id.Equals(model.MemberCardNumber)))
            {
                ModelState.AddModelError(nameof(model.MemberCardNumber), "Member card number already exists.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ic = _identityCardService.GetAll()
                    .FirstOrDefault(c => c.NationalRegistryNumber.Equals(model.NationalRegistryNumber))
                        ?? _identityCardService.Insert(new IdentityCard
                            {
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                BirthDate = model.BirthDate,
                                NationalRegistryNumber = model.NationalRegistryNumber,
                                CardNumber = model.IdCardNumber,
                                ValidDate = model.IdCardValidDate,
                                ExpirationDate = model.IdCardExpirationDate,
                            });

                var mc = new MemberCard
                {
                    Id = model.MemberCardNumber,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    IdentityCardId = ic.Id
                };
                _ = _memberCardService.Insert(mc);

                return Ok(new ResultModel(true, "Member successfully subscribed."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultModel(false, ex.Message));
            }
        }

        [HttpPut("blacklist")]
        public IActionResult Blacklist(BlacklistModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mc = _memberCardService.Get(model.MemberCardNumber);
                mc.BlacklistedUntilDate = model.BlacklistedUntilDate ?? DateTime.MaxValue;
                _memberCardService.Update(mc);
                return Ok(new ResultModel(true, $"Member successfully blacklisted until {mc.BlacklistedUntilDate:dd/MM/yyyy}."));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("updateidcard")]
        public IActionResult UpdateIdCard(UpdateIdentityCardModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ic = _memberCardService.GetAll()
                    .Include(mc => mc.IdentityCard)
                    .FirstOrDefault(mc => mc.Id.Equals(model.MemberCardNumber))
                    ?.IdentityCard;

                if (ic == null)
                {
                    return NotFound(new ResultModel(false, $"No ID card found for member card number \"{model.MemberCardNumber}\"."));
                }

                ic.CardNumber = model.IdCardNumber;
                _identityCardService.Update(ic);
                return Ok(new ResultModel(true, "Identity card number successfully updated."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultModel(false, ex.Message));
            }
        }

        [HttpPut("membercardlost")]
        public IActionResult MemberCardLost(string lostCardNumber, string newCardNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var oldCard = _memberCardService.Get(lostCardNumber);
                var newCard = new MemberCard
                {
                    Id = newCardNumber,
                    Email = oldCard.Email,
                    PhoneNumber = oldCard.PhoneNumber,
                    BlacklistedUntilDate = oldCard.BlacklistedUntilDate,
                    IdentityCardId = oldCard.IdentityCardId
                };
                _memberCardService.Delete(lostCardNumber);
                _memberCardService.Insert(newCard);
                return Ok(new ResultModel(true, "Member card successfully replaced."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultModel(false, ex.Message));
            }
        }
    }
}
