using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Csharp_api.Controllers
{

    [ApiController]
    [Route("/test")]
    public class OtherController : ControllerBase
    {
        public static int jumber = 0;
        
        [HttpGet]
        public int Get()
        {
            return jumber;
        }
    }
}
