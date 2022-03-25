using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoBiking_tc.Proxy.Cache;
using LetsGoBiking_tc.Proxy.Models;
using LetsGoBiking_tc.Proxy.Services.Interfaces;

namespace LetsGoBiking_tc.Proxy.Services
{
    public class JCDecauxService : IJCDecauxService
    {
        private static readonly string KEY = "station";

        private readonly static Cache<JCDecauxObject> cache = new Cache<JCDecauxObject>();
        private readonly double EXPIRATION_TIME = 60;

        public JCDecauxObject GetStationDefault(string city, string stationNumber)
        {
            return GetStation(city, stationNumber, EXPIRATION_TIME);
        }

        public JCDecauxObject GetStation(string city, string stationNumber, double duration)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "city", city },
                { "number", stationNumber }
            };
            return cache.Get("?contract=" + city + "&number=" + stationNumber, duration, dictionary);
        }
    }
}
