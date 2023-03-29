﻿using DrillWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace DrillWebApi.Persistence
{
    public class ApplicationContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HoleLocation> HoleLocations { get; set; }
        public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }

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
