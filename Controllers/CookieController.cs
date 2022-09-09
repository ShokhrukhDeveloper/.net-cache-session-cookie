using Microsoft.AspNetCore.Mvc;

namespace sccm;
[ApiController]
[Route("api/[controller]")]
public class CookieController:ControllerBase{
    

    [HttpGet]
    public IActionResult Get(){
        var count=int.Parse(HttpContext.Session.GetString("count")??"0");
       HttpContext.Session.SetString("count",(++count).ToString());
        return Ok(new Dictionary<string,int>(){{"count",count}});
    }
}