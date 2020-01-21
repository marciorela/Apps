using Apps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Apps.Context
{
    public class AppDbContext : DbContext
    {
        //private readonly IConfiguration configuration;

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<App> Apps { get; set; }

        //public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        //{
        //}

        //public AppDbContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseMySql(config.GetConnectionString("DbMySql"));
        }
    }
}
