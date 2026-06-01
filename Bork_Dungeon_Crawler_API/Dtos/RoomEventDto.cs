namespace Bork_Dungeon_Crawler_API.Dtos
{
    // Represents a room response sent to the client
    // This replaces Console.WriteLine room rendering
    public class RoomEventDto
    {
        // Room title or identifier
        public string Title { get; set; } = null!;

        // Full description text of the room
        public string Description { get; set; } = null!;

        // Available choices (like your "1. Go North")
        public List<string> Choices { get; set; } = new();

        // Optional event type (monster, loot, story etc.)
        public string EventType { get; set; } = "room";
    }
}
