namespace Bork_Dungeon_Crawler_API.Dtos
{
    public class GameEventDto
    {
        // Represents the current turn number in the game
        public int Turn { get; set; }

        // Describes the type of event that occurred in the game
        // Example values: "movement", "monster_encounter", "error"
        public string EventType { get; set; } = null!;

        // A human-readable message describing what happened this turn
        public string Message { get; set; } = null!;
    }
}
