using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Monsters
{
    public class Monster
    {
        // Properties of the Monster
        public string Name { get; set; }
        // Description of the Monster
        public string Description { get; set; }
        // Power level of the Monster
        public int PowerLevel { get; set; }

        // Constructor to initialize a Monster
        public Monster(string name, string description, int powerLevel)
        {
            // Set the properties based on parameters
            Name = name;
            Description = description;
            PowerLevel = powerLevel;
        }
    }
}
