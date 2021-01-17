using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisTemplate.Infrastructure.Data.Interfaces
{
    public interface ICacheContext
    {
        IDatabase Redis { get; }
    }
}
