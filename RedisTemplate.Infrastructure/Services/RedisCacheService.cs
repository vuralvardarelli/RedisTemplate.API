using Newtonsoft.Json;
using RedisTemplate.Infrastructure.Data;
using RedisTemplate.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedisTemplate.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private CacheContext _context;

        public RedisCacheService(CacheContext context)
        {
            _context = context;
        }

        public async Task Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            await _context.Redis.StringSetAsync(key, jsonData);
        }

        public async Task<bool> Any(string key)
        {
            return await _context.Redis.KeyExistsAsync(key);
        }

        public async Task<T> Get<T>(string key)
        {
            if(await Any(key))
            {
                string jsonData = await _context.Redis.StringGetAsync(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public async Task Remove(string key)
        {
            await _context.Redis.KeyDeleteAsync(key);
        }
    }
}
