using Bork_Dungeon_Crawler_API.Data;
using Bork_Dungeon_Crawler_API.Dtos;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Services
{
    // Service responsible for handling game logic and game progression
    public class GameService
    {
        // Database context used to access and update data
        private readonly AppDbContext _context;

        // Constructor where DbContext is injected
        public GameService(AppDbContext context)
        {
            _context = context;
        }

        // Handles the next turn in the game and returns a structured event
        public GameEventDto NextTurn(int characterId)
        {
            // Find the character in the database
            var character = _context.Characters.Find(characterId);

            // If no character is found, return an error event
            if (character == null)
            {
                return new GameEventDto
                {
                    Turn = 0,
                    EventType = "error",
                    Message = "Character not found"
                };
            }

            // Increase the turn counter for this character
            character.TurnCounter++;

            // Save changes to the database
            _context.SaveChanges();

            // Check if this turn triggers a monster encounter
            if (character.TurnCounter % 5 == 0)
            {
                return new GameEventDto
                {
                    Turn = character.TurnCounter,
                    EventType = "monster_encounter",
                    Message = "A wandering monster appears in the dark..."
                };
            }

            // Default event: player moves deeper into the dungeon
            return new GameEventDto
            {
                Turn = character.TurnCounter,
                EventType = "movement",
                Message = $"{character.Username} moves deeper into the dungeon."
            };
        }
    }
}