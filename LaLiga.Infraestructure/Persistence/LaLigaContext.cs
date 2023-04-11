using LaLiga.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LaLiga.Infraestructure.Persistence
{
    public class LaLigaContext : DbContext
    {
        public LaLigaContext(DbContextOptions<LaLigaContext>options): base(options) 
        { 
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<Matches> Matchess { get; set; }
        public DbSet<Teams> Teams { get; set; }

    }
}