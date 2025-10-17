using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Monsters
{
    internal class Monster
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PowerLevel { get; set; }

        public Monster(string name, string description, int powerLevel)
        {
            Name = name;
            Description = description;
            PowerLevel = powerLevel;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Power Level: {PowerLevel}");
            Console.WriteLine();
        }
    }
}
