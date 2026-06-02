using Microsoft.AspNetCore.Mvc;
using Bork_Dungeon_Crawler_API.Services;

namespace Bork_Dungeon_Crawler_API.Controllers
{
    // Kopplar ihop login + character + dungeon start
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        // Hanterar all character-logik (DB + speldata)
        private readonly CharacterService _characterService;

        public GameController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        // Startar spelet efter login
        [HttpGet("start/{userId}")]
        public async Task<IActionResult> StartGame(int userId)
        {
            // Hämta characters för usern
            var characters = await _characterService.GetByUserId(userId);
            var character = characters.FirstOrDefault();

            // Skapa ny character om ingen finns
            if (character == null)
            {
                character = await _characterService.CreateForUser(userId, "Hero");
            }

            // Skicka startdata till client
            return Ok(new
            {
                characterId = character.Id,
                roomId = character.CurrentRoomId,
                username = character.Username
            });
        }
    }
}