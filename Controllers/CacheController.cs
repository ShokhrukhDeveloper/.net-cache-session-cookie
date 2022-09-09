using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace sccm.controller;
[ApiController]
[Route("api/[controller]")]
public class CacheController:ControllerBase
{
    private IMemoryCache _memoryCahe;
    public CacheController(IMemoryCache cache)
    {
        _memoryCahe=cache;
    }
    [HttpGet]
    public IActionResult Get(){
       var resultOfCache= _memoryCahe.GetOrCreate<DateTime>("dateTime",cache=>{
            /// absolute exparition time
            cache.AbsoluteExpirationRelativeToNow=TimeSpan.FromSeconds(30);
            /// sliding exparition  time {from last request}
            cache.SlidingExpiration=TimeSpan.FromSeconds(10);
            return DateTime.Now;
        });
        return Ok(resultOfCache);
    }
}