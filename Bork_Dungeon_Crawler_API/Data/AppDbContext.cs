using Microsoft.EntityFrameworkCore;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Data
{
    // Main database connection used by EF Core
    public class AppDbContext : DbContext
    {
        // Required constructor for dependency injection
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Database tables
        public DbSet<Character> Characters { get; set; }
        public DbSet<Monster> Monsters { get; set; }

        // Relationships configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Monster>()
                .HasOne(m => m.Character)
                .WithMany(c => c.MonstersDefeated)
                .HasForeignKey(m => m.CharacterId);
        }
    }
}
