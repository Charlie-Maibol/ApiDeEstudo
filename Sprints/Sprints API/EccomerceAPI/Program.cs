using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace EccomerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = GetConfiguration(environment);

            LogConfig(configuration);

            try
            {

                Log.Information("Inciando Ecommerce");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erro fatal.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void LogConfig(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Async(l => l.File("C:\\Users\\ClearTech\\Documents\\WorkSpace\\T1-CharlesOliveira\\Sprints\\Sprints API\\EccomerceAPI\\Logs\\log.txt", fileSizeLimitBytes: 1000000, rollOnFileSizeLimit: true,
                rollingInterval: RollingInterval.Day))
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static IConfigurationRoot GetConfiguration(string environment)
        {
            return new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{environment}.json")
                            .Build();
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
