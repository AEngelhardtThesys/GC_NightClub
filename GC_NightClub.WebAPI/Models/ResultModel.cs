using Newtonsoft.Json;

namespace GC_NightClub.WebAPI.Models
{
    public class ResultModel(bool success, string message)
    {
        [JsonProperty("success")] public bool Success { get; set; } = success;

        [JsonProperty("message")] public string Message { get; set; } = message;
    }
}
