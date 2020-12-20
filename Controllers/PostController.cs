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
            
            if(data.Length > 10000) {
                data = data.Substring(0, 10000);
            }

            string[] wordList = data.Split(' ').Select(str => str.Trim()).ToArray();

            string[] prossesedWordList = new string[wordList.Length];

            //string output = wordList[0].ToLower().ToString();

            string output;

            //System.Console.WriteLine("\"" + output + "\"");

            output = "";

            List<Thread> myListThingGräj = new List<Thread>();

            for (int i = 0; i < wordList.Length; i++)
            {
                myListThingGräj.Add(new Thread(setPartOfArray));
                myListThingGräj[i].Start(i);
            }

            /*for (int i = 0; i < wordList.Length; i++)
            {
                setPartOfArray(i);
            }*/

            foreach (var item in myListThingGräj)
            {
                item.Join();
            }

            foreach (var item in prossesedWordList)
            {
                output += item + " ";
            }

            return output;

            void setPartOfArray(object position) {
                var pos = int.Parse(position.ToString());
                prossesedWordList[pos] = Synonyms.getSynonym(wordList[pos]);
            }
        }
    }
}
