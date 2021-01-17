using System;
using System.Collections.Generic;
using System.Text;

namespace RedisTemplate.Core.Models.Entities
{
    public class RedisItem
    {
        public string Key { get; set; }

        public object Value { get; set; }
    }
}
