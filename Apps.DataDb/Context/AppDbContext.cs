using Apps.DataDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Apps.Utils;

namespace Apps.DataDb.Context
{
    public class AppDbContext : DbContext
    {
        //private readonly IConfiguration configuration;

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
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

            optionsBuilder.UseMySql(Config.Read("ConnectionStrings:DbMySql"));
            
/*
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseMySql(config.GetValue<string>("ConnectionStrings:DbMySql"));
//            optionsBuilder.UseMySql(config.GetConnectionString("DbMySql"));
*/
        }
    }
}
