using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //using (var wh = WebHost.Start("http://localhost:8080",
            //                contex => contex.Response.WriteAsync("YO")))
            //{

            //    Console.WriteLine("started");
            //    wh.WaitForShutdown();
            //}   
            


            //var host = new WebHostBuilder()
            //                    .UseKestrel()
            //                    .UseContentRoot(Directory.GetCurrentDirectory())                                
            //                    .UseStartup<Startup>()
            //                    .Build();

            //host.Run();

            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
                {                    
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseWebRoot("static");
                });
    }
}
