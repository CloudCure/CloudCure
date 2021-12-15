using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
             Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(),"Logs/log.json", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try {

                Log.Information("Starting");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application Startup Failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
