using APITest.Requests;
using Microsoft.AspNetCore.Mvc;
using APITest.Services;
using APITest.Structures;
using Newtonsoft.Json;

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

        [HttpPost]
        [HttpGet]
        [Produces("application/json")]
        [Route("create_calc")]
        public async Task<IActionResult> CreateCalc()
        {
            WebApplicationRequest request = new WebApplicationRequest(this.Request);

            string path = Path.Combine(@"C:\test", "json_settings.txt");
            List<Structures.Results> content = new List<Structures.Results>();
            string str_content = System.IO.File.ReadAllText(path);  
            if (!string.IsNullOrEmpty(str_content))
            {
                content = JsonConvert.DeserializeObject<List<Structures.Results>>(str_content);

            }
            Structures.Results elem = new Structures.Results();
            elem.uuid = Guid.NewGuid().ToString();
            elem.result = 0.5 * request.HeightT * request.BaseT * request.HeightP;
            content.Add(elem);

            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(content));
            
            return this.Json(elem);
        }

        [HttpPost]
        [HttpGet]
        [Produces("application/json")]
        [Route("get_one_calc")]
        public async Task<IActionResult> GetOneCulc()
        {
            WebApplicationRequest request = new WebApplicationRequest(this.Request);

            string path = Path.Combine(@"C:\test", "json_settings.txt");
            Structures.Results obj = null;
            string str_content = System.IO.File.ReadAllText(path);
            if (!string.IsNullOrEmpty (str_content))
            {
                List<Structures.Results> content = JsonConvert.DeserializeObject<List<Structures.Results>>(str_content);
                foreach (var c in content)
                {
                    if (c.uuid == request.Guid)
                    {
                        obj = c;
                    }
                }
            }

            return this.Json(obj); 
        }

        [HttpPost]
        [HttpGet]
        [Produces("application/json")]
        [Route("update_one_calc")]
        public async Task<IActionResult> UpdateOneCulc()
        {
            WebApplicationRequest request = new WebApplicationRequest(this.Request);
            bool update = false;

            List<Structures.Results> content = new List<Structures.Results>();
            string path = Path.Combine(@"C:\test", "json_settings.txt");
            string str_content = System.IO.File.ReadAllText(path);
            if (!string.IsNullOrEmpty(str_content))
            {
                content = JsonConvert.DeserializeObject<List<Structures.Results>>(str_content);
                foreach (var b in content)
                {
                    if (b.uuid == request.Guid)
                    {
                        b.result = 0.5 * request.HeightT * request.BaseT * request.HeightP;
                        update = true;
                    }
                }
            }
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(content));

            return this.Json(new
            {
                result = update
            });
        }

        [HttpPost]
        [HttpGet]
        [Produces("application/json")]
        [Route("delete_one_calc")]
        public async Task<IActionResult> DeleteOneCulc()
        {
            WebApplicationRequest request = new WebApplicationRequest(this.Request);
            bool del = false;

            List<Structures.Results> content = new List<Structures.Results>();
            List<Structures.Results> final = new List<Structures.Results>();
            string path = Path.Combine(@"C:\test", "json_settings.txt");
            string str_content = System.IO.File.ReadAllText(path);

            if (!string.IsNullOrEmpty(str_content))
            {
                content = JsonConvert.DeserializeObject<List<Structures.Results>>(str_content);
                foreach (var b in content)
                {
                    if (b.uuid == request.Guid)
                    {
                        final.Add(b);
                        del = true;
                    }
                }
            }
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(final));

            return this.Json(new
            {
                result = del
            });
        }
    }
}