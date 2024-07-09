using System.ComponentModel.DataAnnotations;
using GC_NightClub.WebAPI.Domain.Attributes;
using Newtonsoft.Json;

namespace GC_NightClub.WebAPI.Models
{
    public class CreateCardModel
    {
        [JsonProperty("memberCardNumber")]
        [Required]
        public string MemberCardNumber { get; set; }

        [JsonProperty("firstName")]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        public string LastName { get; set; }

        [JsonProperty("birthDate")]
        [LegalAge]
        [Required]
        public DateTime BirthDate { get; set; }

        [JsonProperty("nationalRegistryNumber")]
        [ValidateWithRegex(@"^\d{2}.\d{2}.\d{2}[-]\d{3}.\d{2}$", nameof(NationalRegistryNumber), "##.##.##-###.##")]
        public string NationalRegistryNumber { get; set; }

        [JsonProperty("cardNumber")]
        [ValidateWithRegex(@"^\d{3}[-]\d{7}[-]\d{2}$", nameof(IdCardNumber), "###-#######-##")]
        public string IdCardNumber { get; set; }

        [JsonProperty("validDate")]
        [PastDate("Validity date")]
        [Required]
        public DateTime IdCardValidDate { get; set; }

        [JsonProperty("expirationDate")]
        [FutureDate("Expiration date")]
        [Required]
        public DateTime IdCardExpirationDate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
