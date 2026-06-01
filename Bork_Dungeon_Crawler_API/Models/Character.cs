namespace Bork_Dungeon_Crawler_API.Models
{
    // Represents a player character stored in the database
    // This is the main player entity used throughout the game API
    public class Character
    {
        // Primary key used by Entity Framework Core
        public int Id { get; set; }

        // The player's username displayed in-game
        public string Username { get; set; } = null!;

        // Hashed password for authentication (never store plain text passwords)
        public string PasswordHash { get; set; } = null!;

        // Represents the player's progression or strength level
        public int PowerLevel { get; set; }

        // Tracks how many actions/turns the player has taken in the dungeon
        public int TurnCounter { get; set; }

        // Timestamp for when this character was created
        public DateTime CreatedAt { get; set; }


        // Stores the ID of the room the player is currently in
        // This replaces your old console-based room navigation system
        public int CurrentRoomId { get; set; }

        // Optional navigation property for Entity Framework relationships
        public Room? CurrentRoom { get; set; }


        // List of monsters this character has defeated
        // Will be used later for stats, achievements or inventory systems
        public ICollection<Monster> MonstersDefeated { get; set; }
            = new List<Monster>();
    }
}