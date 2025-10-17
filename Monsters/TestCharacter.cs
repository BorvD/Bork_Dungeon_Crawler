using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Monsters
{
    // Class for running the game without running without registering a char etc 
    public class TestCharacter
    {
        // Name of the hero
        public string Name { get; private set; }
        // Power level of the hero
        public int PowerLevel { get; private set; }
        // Constructor that sets the players name and power level
        public int TurnCounter { get; private set; }

        public TestCharacter(string name, int powerLevel)
        {
            Name = name;
            PowerLevel = powerLevel;
            // Turncounter that starts att zero, used for Wandering monster
            TurnCounter = 0;
        }

        // Metod that is called on when the player enters a new room
        public void EnterRoom()
        {
            // When the player enters a new room the count goes up by 1
            TurnCounter++;
        }
    }
}
