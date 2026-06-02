namespace Bork_Dungeon_Crawler_API.Models
{
    // Represents a real user account in the system
    // This replaces the old Console-based login system
    public class AppUser
    {
        // Primary key in database
        public int Id { get; set; }

        // Username used to identify the user
        public string Username { get; set; } = null!;

        // Hashed password (NEVER store plain text passwords)
        public string PasswordHash { get; set; } = null!;
    }
}