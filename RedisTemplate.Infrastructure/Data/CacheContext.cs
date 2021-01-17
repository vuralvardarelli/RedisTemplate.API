using RedisTemplate.Infrastructure.Data.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisTemplate.Infrastructure.Data
{
    public class CacheContext : ICacheContext
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public CacheContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            Redis = redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
