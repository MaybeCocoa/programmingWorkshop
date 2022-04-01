using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace APITest.Requests
{
    public class WebApplicationRequest
    {
        public double HeightT { get; set; } = 0.0;
        public double BaseT { get; set; } = 0.0;
        public double HeightP { get; set; } = 0.0;
        public string Guid { get; set; }

        public WebApplicationRequest(HttpRequest request)
        {
            var form = request.Form.ToList();

            foreach (var param in form)
            {
                switch (param.Key.ToLower())
                {
                    case "heightt":
                        this.HeightT = Convert.ToDouble(param.Value.ToArray()[0].ToString());
                        break;
                    case "baset":
                        this.BaseT = Convert.ToDouble(param.Value.ToArray()[0].ToString());
                        break;
                    case "heightp":
                        this.HeightP = Convert.ToDouble(param.Value.ToArray()[0].ToString());
                        break;
                    case "uuid":
                        this.Guid = param.Value;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
