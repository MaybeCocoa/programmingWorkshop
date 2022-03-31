using APITest.Requests;
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
        [Route("prism")]

        public async Task<IActionResult> PrismArea()
        {
            WebApplicationRequest request = new WebApplicationRequest(this.Request);
            
            double square = 0.5 * request.HeightT * request.BaseT * request.HeightP;

            MyClassResponse res = new MyClassResponse();
            res.Success = "success";
            res.Result = square;
            res.Version = "1.0";
            return this.Json(res);
        }
    }
}