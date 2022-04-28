using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace LetsGoBiking_tc.Proxy
{
    internal class ProxyCache<T>
    {
        private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly Func<string, Task<T>> _defaultHandler;
        
        public ProxyCache(Func<string, Task<T>> defaultHandler)
        {
            _defaultHandler = defaultHandler;
        }

        public async Task<T> Get(string key) => await Get(key, 5);

        public async Task<T> Get(string key, double minutes) => await Get(key, DateTimeOffset.Now.AddMinutes(minutes));

        public async Task<T> Get(string key, DateTimeOffset offset)
        {
            if (_cache.Get(key) is T x)
                return x;

            var value = (await _defaultHandler(key))!;
            _cache.Add(key, value, offset);
            return value;
        }
    }
}