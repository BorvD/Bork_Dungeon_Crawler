using Microsoft.AspNetCore.Mvc;
using Bork_Dungeon_Crawler_API.Services;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Controllers
{
    // This controller handles ALL dungeon movement from the client
    // It replaces your old Console-based "choose direction" logic
    [ApiController]
    [Route("api/dungeon")]
    public class DungeonController : ControllerBase
    {
        // Service that contains ALL dungeon logic:
        //  movement
        //  rooms
        //  turn system
        //  encounters
        private readonly DungeonRoomService _dungeonService;

        // Dependency Injection
        // ASP.NET injects DungeonRoomService automatically
        public DungeonController(DungeonRoomService dungeonService)
        {
            _dungeonService = dungeonService;
        }


        // MOVE PLAYER


        // - OPTIONAL monster encounter
        [HttpPost("move")]
        public ActionResult<RoomResponse> Move([FromBody] MoveRequest request)
        {
            var result = _dungeonService.Move(request.CharacterId, request.Direction);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Invalid move"
                });
            }

            return Ok(result);
        }



        // GET CURRENT ROOM (optional endpoint)

        [HttpGet("current")]
        public ActionResult<RoomResponse> GetCurrentRoom(int characterId)
        {
            var room = _dungeonService.GetCurrentRoom(characterId);

            // Convert Room → RoomResponse (no encounter here)
            var response = new RoomResponse
            {
                RoomId = room.Id,
                Title = room.Title,
                Description = room.Description,
                Options = room.Exits.Keys.ToList(),
                Encounter = null
            };

            return Ok(response);
        }
    }
}