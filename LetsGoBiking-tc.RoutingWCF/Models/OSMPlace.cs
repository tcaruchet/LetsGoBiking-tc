using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.RoutingWCF.Models
{
    public class OSMPlace
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
