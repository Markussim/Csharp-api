using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Csharp_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Synonyms.sort();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    /*try
                    {
                        webBuilder.UseUrls("http://0.0.0.0:" + Environment.GetEnvironmentVariable("PORT"));
                    }
                    catch (System.Exception)
                    {
                    }*/
                    
                });
    }
}
