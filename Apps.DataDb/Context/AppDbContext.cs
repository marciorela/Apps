using Apps.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Apps.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<App> Apps { get; set; }

        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
