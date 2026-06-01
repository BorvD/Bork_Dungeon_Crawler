using Bork_Dungeon_Crawler_API.Dtos;

namespace Bork_Dungeon_Crawler_API.Models
{
    // This class represents the data returned to the frontend
    // whenever the player enters or moves to a new room.
    public class RoomResponse
    {
        // Unique identifier for the room the player is currently in
        public int RoomId { get; set; }

        // Display name of the room (used in UI or logs)
        public string Title { get; set; } = "";

        // Full room description split into lines
        // This replaces Console.WriteLine storytelling from the old version
        public List<string> Description { get; set; } = new();

        // Available player actions (e.g. "north", "south", "search")
        // These correspond to exits or interactions in the room
        public List<string> Options { get; set; } = new();

        public MonsterEventDto? Encounter { get; set; }
    }
}