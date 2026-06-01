namespace Bork_Dungeon_Crawler_API.Dtos
{
    // DTO used when a monster encounter happens in the game
    public class MonsterEventDto
    {
        // Name of the monster that appears
        public string MonsterName { get; set; } = null!;

        // Short description of the monster
        public string Description { get; set; } = null!;

        // Power level (used later for combat system, when it is implemented)
        public int PowerLevel { get; set; }

        // Message shown to the player
        public string Message { get; set; } = null!;
    }
}
