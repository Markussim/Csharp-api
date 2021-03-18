using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Diagnostics;


namespace Csharp_api.Controllers
{


    [ApiController]
    [Route("/test")]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public String Post(int? id)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string data = Request.Form["word"];

            if (data.Length > 10000)
            {
                data = data.Substring(0, 10000);
            }

            string[] wordList = data.Split(' ').Select(str => str.Trim()).ToArray();

            string[] prossesedWordList = new string[wordList.Length];

            //string output = wordList[0].ToLower().ToString();

            string output;

            //System.Console.WriteLine("\"" + output + "\"");

            output = "";

            List<Thread> myListThingGräj = new List<Thread>();

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                //System.Console.WriteLine("Got here");
                int start = ((wordList.Length / Environment.ProcessorCount) * i);

                int end = start + (wordList.Length / Environment.ProcessorCount);

                myListThingGräj.Add(new Thread(() => setPartOfArray(start, end)));
                myListThingGräj[i].Start();
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

            sw.Stop();

            System.Console.WriteLine((int)((sw.Elapsed.TotalMilliseconds / wordList.Length) * 1000) + " μs");

            return output;

            void setPartOfArray(int startPosition, int endPosition)
            {
                for (int i = startPosition; i < endPosition; i++)
                {

                    try
                    {
                        prossesedWordList[i] = Synonyms.getSynonym(wordList[i]);
                    }
                    catch (System.Exception)
                    {
                        System.Console.WriteLine(i);
                        throw;
                    }

                }
            }
        }
    }
}
