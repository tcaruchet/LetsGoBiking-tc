using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoBiking_tc.Proxy.Cache
{
    internal interface ICache<T>
    {
        T Get(string cacheItem, Dictionary<string, string> dictionary);

        T Get(string cacheItem, double dtSeconds, Dictionary<string, string> dictionary);

        T Get(string cacheItem, DateTimeOffset dt, Dictionary<string, string> dictionary);
    }
}
