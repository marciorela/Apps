using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;

namespace Apps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true)
               .Build();

            //Ativa o log, para logar erros ocultos quando estiver debugando
            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
            Serilog.Debugging.SelfLog.Enable(Console.Error);

            //Configurando LOG
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                            .MinimumLevel.Override("System", LogEventLevel.Warning)
                            .Enrich.FromLogContext()
                            .Enrich.WithExceptionDetails()
                            .Enrich.WithMachineName()
                            .Enrich.WithProperty("Application", "Apps")
                            .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                            .Enrich.WithEnvironmentUserName()
                            .Enrich.WithProcessId()
                            .Enrich.WithProcessName()
                            .Enrich.WithMemoryUsage()
                            .Enrich.WithAssemblyVersion()
                            .Enrich.WithDemystifiedStackTraces()
                            .ReadFrom.Configuration(configuration)
                            .WriteTo.Async(a =>
                            {
                                //Logar em Arquivo
                                a.File(new CompactJsonFormatter(), ".\\logs\\log_.txt", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 1024 * 1024 * 20, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(1), rollOnFileSizeLimit: true);
                                //Logar no Console
                                a.ColoredConsole(LogEventLevel.Verbose, "{AssemblyVersion} {MemoryUsage} {NewLine}{Timestamp:HH:mm:ss.fff} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception} {Properties:j}");
                            }, bufferSize: 500)
                            .CreateLogger();
            
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush(); // Feche e limpe o log.
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddSerilog();
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
