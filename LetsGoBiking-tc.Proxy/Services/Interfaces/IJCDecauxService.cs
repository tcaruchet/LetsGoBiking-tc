using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LetsGoBiking_tc.Proxy.Models;

namespace LetsGoBiking_tc.Proxy.Services.Interfaces
{
    internal interface IJCDecauxService
    {
        JCDecauxObject GetStationDefault(string city, string stationNumber);

        JCDecauxObject GetStation(string city, string stationNumber, double duration);
    }
}
