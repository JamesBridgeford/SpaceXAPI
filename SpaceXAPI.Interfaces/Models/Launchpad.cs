using Newtonsoft.Json;

namespace SpaceXAPI.Models
{
    public class Launchpad
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("full_name")]
        public string Name { get; set; }

    }
}
