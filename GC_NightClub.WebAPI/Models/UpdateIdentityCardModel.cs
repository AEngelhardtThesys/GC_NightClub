using System.ComponentModel.DataAnnotations;
using GC_NightClub.WebAPI.Domain.Attributes;
using Newtonsoft.Json;

namespace GC_NightClub.WebAPI.Models
{
    public class UpdateIdentityCardModel
    {
        public string MemberCardNumber { get; set; }

        [JsonProperty("identityCardNumber")]
        [ValidateWithRegex(@"^\d{3}[-]\d{7}[-]\d{2}$", nameof(IdCardNumber), "###-#######-##")]
        [Required]
        public string IdCardNumber { get; set; }
    }
}
