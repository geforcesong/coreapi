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
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false).Build();

            ServerSettings serverSettings = new ServerSettings();
            config.GetSection("Server").Bind(serverSettings);

            CreateWebHostBuilder(args, serverSettings).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, ServerSettings serverSettings)
        {
            return WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>().UseKestrel(options =>
                   {
                       options.Listen(System.Net.IPAddress.Loopback, serverSettings.Port);
                   });
        }
    }
}
