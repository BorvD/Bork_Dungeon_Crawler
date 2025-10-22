using Bork_Dungeon_Crawler.Monsters;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Bork_Dungeon_Crawler
{

    internal class Program
    {

        static void Main(string[] args)
        {
            // Start the main menu
            //MainMenu menu = new MainMenu();
            //menu.mainMenu();




            // För att köra tester som hoppar över registrering och liknande
            Console.Write("Enter your hero's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your starting power level (e.g., 5): ");
            int powerLevel = Convert.ToInt32(Console.ReadLine());
            TestCharacter player = new TestCharacter(name, powerLevel);
            WanderingMonster wanderingMonster = new WanderingMonster();
            TurnManager turnManager = new TurnManager(player, wanderingMonster);
            Room_01_00 startRoom = new Room_01_00();
            startRoom.initialize(player, turnManager);
            startRoom.enterRoom();
        }
    }
}
