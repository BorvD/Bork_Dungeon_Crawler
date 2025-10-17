using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    public class Room_01_02 : BaseRoom
    {
        public override void enterRoom()
        {
            turnManager.checkTurn(() => enterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The passage widens briefly into a low alcove.");
            Console.WriteLine("Faded markings cover the walls, their meaning long forgotten.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Go East.");
                Console.WriteLine("2. Go West.");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Move East → Room_01_01
                    Room_01_01 nextRoom = new Room_01_01();
                    nextRoom.initialize(player, turnManager);
                    nextRoom.enterRoom();
                    break;
                }
                else if (input == "2")
                {
                    // Move West → Room_01_03
                    Room_01_03 nextRoom = new Room_01_03();
                    nextRoom.initialize(player, turnManager);
                    nextRoom.enterRoom();
                    break;
                }
                else
                {
                    Console.WriteLine("Can not be done!");
                }
            }
        }
    }
}
