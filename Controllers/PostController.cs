using System;
using System.IO;
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
        public String Post(int? id)
        {
            string data = Request.Form["word"];

            string[] wordList = data.Split(' ').Select(str => str.Trim()).ToArray();

            //string output = wordList[0].ToLower().ToString();

            string output;

            //System.Console.WriteLine("\"" + output + "\"");

            output = "";

            foreach (var item in wordList)
            {
                output += Synonyms.getSynonym(item.ToLower()) + " ";
            }

            return output;
        }
    }
}
