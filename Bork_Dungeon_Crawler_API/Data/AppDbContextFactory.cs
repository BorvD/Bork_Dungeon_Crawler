using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Bork_Dungeon_Crawler_API.Data;

namespace Bork_Dungeon_Crawler_API.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=BorkDungeonDb;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
