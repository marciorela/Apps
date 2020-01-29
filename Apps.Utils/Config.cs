using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Apps.Utils
{
    public static class Config
    {
        
        public static string Read(string Key)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();
            return config.GetValue<string>(Key);
        }

        public static string UrlApi()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                return "https://localhost:44358/app/";
            } else
            {
                return "http://192.168.1.51:8088/appapi/app/";
            }
                        
        }
    }
}
