using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoBiking_tc.Proxy.Cache
{
    public class Cache<T> : ICache<T> where T : new()
    {
        private readonly ObjectCache _cache;
        private DateTimeOffset DateDefault { get; set; }

        public Cache()
        {
            _cache = MemoryCache.Default;
            DateDefault = ObjectCache.InfiniteAbsoluteExpiration;
        }

        public T Get(string cacheItem, Dictionary<string, string> dictionary)
        {
            return Get(cacheItem, DateDefault, dictionary);
        }

        public T Get(string cacheItem, double dtSeconds, Dictionary<string, string> dictionary)
        {
            return Get(cacheItem, DateTimeOffset.Now.AddSeconds(dtSeconds), dictionary);
        }

        public T Get(string cacheItem, DateTimeOffset dt, Dictionary<string, string> dictionary)
        {
            if (_cache.Get(cacheItem) == null)
            {
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = dt
                };
                _ = _cache.Add(cacheItem, (T)Activator.CreateInstance(typeof(T), dictionary) ?? new T(), cacheItemPolicy);
            }
            return (T)_cache.Get(cacheItem);
        }
    }
}
