using Newtonsoft.Json;

namespace LetsGoBiking_tc.Routing.Models
{
    public class Place
    {
        [JsonProperty("display_name")]
        public string Name { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("importance")]
        public double Importance { get; set; }
    }
}
