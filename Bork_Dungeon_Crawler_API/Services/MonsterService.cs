
using Bork_Dungeon_Crawler_API.Data;
using Bork_Dungeon_Crawler_API.Dtos;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Services
{
    // Handles monster encounters and logic
    public class MonsterService
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();

        public MonsterService(AppDbContext context)
        {
            _context = context;
        }

        // Creates a random monster encounter
        public MonsterEventDto GenerateEncounter()
        {
            // Get a random monster from database
            var monsters = _context.Monsters.ToList();

            if (!monsters.Any())
            {
                return new MonsterEventDto
                {
                    MonsterName = "Empty Dungeon",
                    Description = "There are no monsters here... yet.",
                    PowerLevel = 0,
                    Message = "The dungeon feels strangely quiet."
                };
            }

            var monster = monsters[_random.Next(monsters.Count)];

            return new MonsterEventDto
            {
                MonsterName = monster.Name,
                Description = monster.Description,
                PowerLevel = monster.PowerLevel,
                Message = $"A wild {monster.Name} appears from the shadows!"
            };
        }
    }
}