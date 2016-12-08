
namespace Serenity.Caching
{
    using Serenity.Abstractions;
    using System;
    using System.Collections;
    using System.Runtime.Caching;

    public class MemoryCache : ILocalCache
    {
        private System.Runtime.Caching.MemoryCache cache;

        public MemoryCache()
        {
            this.cache = new System.Runtime.Caching.MemoryCache("MyCache");
        }

        public void Add(string key, object value, TimeSpan expiration)
        {
            this.cache.Set(key, value, expiration == TimeSpan.Zero ? DateTimeOffset.MaxValue :
                DateTimeOffset.Now.Add(expiration)); 
        }

        public TItem Get<TItem>(string key)
        {
            return (TItem)this.cache.Get(key);
        }

        public object Remove(string key)
        {
            return this.cache.Remove(key);
        }

        public void RemoveAll()
        {
            var cache = this.cache;
            foreach (var k in cache)
                cache.Remove((string)k.Key);
        }
    }
}