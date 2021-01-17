using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisTemplate.Core.Models.Common;
using RedisTemplate.Core.Models.Entities;
using RedisTemplate.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisTemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpPost("Add")]
        public async Task<Result> Add([FromBody] RedisItem item)
        {
            Result rslt = new Result();

            try
            {

                object itemVal = item.Value as object;
                await _cacheService.Add(item.Key, itemVal);

                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }
    }
}
