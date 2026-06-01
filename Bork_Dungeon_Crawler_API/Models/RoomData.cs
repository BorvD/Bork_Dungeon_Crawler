namespace Bork_Dungeon_Crawler_API.Models
{
    // Pure data model for a dungeon room
    // Replaces ALL old Room_01_XX classes
    public class RoomData
    {
        public int Id { get; set; }

        // Room title (optional for frontend)
        public string Title { get; set; } = "";

        // Full story text (Console.WriteLine replacement)
        public List<string> Description { get; set; } = new();

        // Key = direction ("north", "south")
        // Value = next room id
        public Dictionary<string, int> Exits { get; set; } = new();
    }
}