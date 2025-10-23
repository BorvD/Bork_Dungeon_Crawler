using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_09 : BaseRoom
    {
        public override void enterRoom()
        {
            turnManager?.checkTurn(() => enterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You step into a narrow storage alcove. A few shattered jars leak a dark, sticky residue across the floor.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Go East.");
                Console.WriteLine("2. Go West.");
                string input = Console.ReadLine();

                checkForOverlay(input, () => enterRoom());

                if (input == "1")
                {
                    Room_01_08 room_01_08 = new Room_01_08();
                    room_01_08.initialize(player, turnManager);
                    room_01_08.enterRoom();
                    break;
                }
                else if (input == "2")
                {
                    Room_01_10 room_01_10 = new Room_01_10();
                    room_01_10.initialize(player, turnManager);
                    room_01_10.enterRoom();
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
