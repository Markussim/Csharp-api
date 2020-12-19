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
    [Route("/test")]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public String Post()
        {
            return Synonyms.getSynonym("hello");
        }
    }
}
