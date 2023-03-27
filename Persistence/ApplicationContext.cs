using DrillWebApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DrillWebApi.Persistence
{
    public class ApplicationContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<Hole> Holes { get; set; }

        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
