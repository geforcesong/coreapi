using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using coreapi.Models.Settings;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace coreapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .Build();
            return WebHost.CreateDefaultBuilder(args)
                          .UseConfiguration(config)
                          //.ConfigureLogging((hostingContext, logging) =>
                          //{
                          //    logging.AddConfiguration(config.GetSection("Logging"));
                          //    logging.AddConsole();
                          //    logging.AddDebug();
                          //    logging.AddEventSourceLogger();
                          //})
                          .UseStartup<Startup>();
        }
    }
}
