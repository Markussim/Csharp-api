using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;


namespace Csharp_api.Controllers
{


    [ApiController]
    [Route("/")]
    public class OtherController : ControllerBase
    {
        public static bool debug = true;
        public static String result = System.IO.File.ReadAllText(@"./data/synonym.html");

        [HttpGet]
        public ActionResult Get()
        {
            if(debug) {
                return Content(System.IO.File.ReadAllText(@"./data/synonym.html"), "text/html");
            }
            return Content(result, "text/html");
        }
    }
}
