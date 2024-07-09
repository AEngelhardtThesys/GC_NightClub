using System.ComponentModel.DataAnnotations;
using GC_NightClub.WebAPI.Domain.Attributes;
using Newtonsoft.Json;

namespace GC_NightClub.WebAPI.Models
{
    public class BlacklistModel
    {
        [JsonProperty("memberCardNumber")]
        [Required]
        public string MemberCardNumber { get; set; }

        [JsonProperty("blacklistUntilDate")]
        [FutureDate(nameof(BlacklistedUntilDate))]
        [Required]
        public DateTime? BlacklistedUntilDate { get; set; }
    }
}
