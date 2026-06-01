namespace Bork_Dungeon_Crawler_API.Models
{
    // Denna klass representerar ett monster i spelet
    // Kommer bli en tabell i databasen: Monsters
    public class Monster
    {
        // Primärnyckel
        public int Id { get; set; }

        // Namn på monstret (t.ex. Zombie, Imp)
        public string Name { get; set; } = null!;

        // Kort beskrivning (flavor text / lore)
        public string Description { get; set; } = null!;

        // Hur starkt monstret är
        public int PowerLevel { get; set; }

        // Foreign key
        // Detta kopplar monstret till en Character i databasen
        // (vilken spelare som "äger" eller har besegrat monstret)
        public int CharacterId { get; set; }

        // Navigation property tillbaka till Character
        // Gör att vi kan komma åt:
        // monster.Character.Username
        public Character Character { get; set; } = null!;
    }
}
