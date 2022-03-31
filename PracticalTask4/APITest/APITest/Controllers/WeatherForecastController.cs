using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers
{
    [ApiController]
    [Route("test")]
    public class WeatherForecastController : Controller
    {
        [HttpPost]
        [HttpGet]
        [Produces("application/json")]
        [Route("index")]

        public async Task<IActionResult> Index()
        {
            return this.Json(new { result = "Hello World!" });
        }

        [HttpPost]
        [HttpGet]
        [Produces("application/json")]
        [Route("hw")]

        public async Task<IActionResult> Test()
        {
            MyClassRes res = new MyClassRes();
            res.Success = "success";
            res.Result = "hello!";
            res.Version = "1.0";
            return this.Json(res);
        }
    }
}