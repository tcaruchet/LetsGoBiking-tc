using LetsGoBiking_tc.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LetsGoBiking_tc.Lib;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.Proxy.Models
{
    public class JCDecauxObject
    {
        public Station Station { get; set; }

        public JCDecauxObject()
        {
        }

        public JCDecauxObject(Dictionary<string, string> dictionary)
        {
            Station = UpdateStation(dictionary).Result;
        }

        private async Task<Station> UpdateStation(Dictionary<string, string> dictionary)
        {
            try
            {
                string response = await JCDecaux.Client.GetStringAsync(JCDecaux.GetUrl("stations/" + dictionary["number"] + "?contract=" + dictionary["city"]));
                Station = JsonConvert.DeserializeObject<Station>(response);
                return Station ?? new Station();
            }
            catch (HttpRequestException)
            {
                return new Station();
            }
        }

    }
}
