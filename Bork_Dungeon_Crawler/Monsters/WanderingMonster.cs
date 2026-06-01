using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Monsters
{
    public class WanderingMonster
    {
        // List of possible monsters with their descriptions and power levels from the Monster class
        private List<(string Name, string Description, int Power)> monsters = new List<(string, string, int)>
        {
            ("Zombie", "One of the living dead.", 2),
            ("Specter", "Ghostly and draining.", 3),
            ("Imp", "Mischievous fire demon.", 1),
         };

        // Method to start a random encounter
        public void startEncounter()
        {
            // Select a random monster
            Random rnd = new Random();
            // Create a random number generator within the method to pick a random monster from the list above
            var monster = monsters[rnd.Next(monsters.Count)];

            // Display encounter message
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A {monster.Name} appears! {monster.Description}");
            Console.ForegroundColor = ConsoleColor.White;

            // Encinter menu of what the player can do
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");

            // Get player choice
            string choice = Console.ReadLine();

            // What happens based on player choice in a if statement
            if (choice == "1")
            {
                Console.WriteLine($"You attack the {monster.Name}!");
                Console.WriteLine($"After a brief struggle, you defeat the creature!");
            }
            else
            {
                Console.WriteLine($"You manage to escape from the {monster.Name}...");
            }

            Console.WriteLine("The danger passes... You continue your journey.");
        }
    }    
}