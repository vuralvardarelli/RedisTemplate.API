using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedisTemplate.Infrastructure.Services.Interfaces
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task Add(string key, object data);
        Task Remove(string key);
        Task<bool> Any(string key);
    }
}
