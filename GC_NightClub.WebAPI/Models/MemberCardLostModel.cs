using Newtonsoft.Json;

namespace GC_NightClub.WebAPI.Models
{
    public class MemberCardLostModel
    {
        [JsonProperty("lostCardNumber")]
        public string LostCardNumber { get; set; }

        [JsonProperty("newCardNumber")]
        public string newCardNumber { get; set; }
    }
}
