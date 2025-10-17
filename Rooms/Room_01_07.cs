using Bork_Dungeon_Crawler.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_07 : BaseRoom
    {
        public override void enterRoom()
        {
            // Optional — safety check in case something didn't initialize
            turnManager.checkTurn(() => enterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The room is small and bare, save for a single torch still burning low — someone has been here recently.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Go South.");
                Console.WriteLine("2. Go North.");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Room_01_08 room_01_08 = new Room_01_08();
                    room_01_08.initialize(player, turnManager);
                    room_01_08.enterRoom();  // ✅ use EnterRoom()
                    break;
                }
                else if (input == "2")
                {
                    Room_01_06 room_01_06 = new Room_01_06();
                    room_01_06.initialize(player, turnManager);
                    room_01_06.enterRoom();  // ✅ use EnterRoom()
                    break;
                }
                else
                {
                    Console.WriteLine("Can not be done!");
                    continue;
                }
            }
        }
    }
}
