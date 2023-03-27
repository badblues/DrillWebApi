using DrillWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace DrillWebApi.Persistence
{
    public class ApplicationContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<DrillBlock> DrillBlocks { get; set; }

        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
