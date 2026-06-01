using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_13 : BaseRoom
    {
        public override void enterRoom()
        {
            turnManager?.checkTurn(() => enterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This chamber smells of mildew and rust. A broken spear rests against the wall, its tip long gone.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Go South.");
                Console.WriteLine("2. Go North.");
                string input = Console.ReadLine();

                checkForOverlay(input, () => enterRoom());

                if (input == "1")
                {
                    Room_01_14 room_01_14 = new Room_01_14();
                    room_01_14.initialize(player, turnManager);
                    room_01_14.enterRoom();
                    break;
                }
                else if (input == "2")
                {
                    Room_01_08 room_01_08 = new Room_01_08();
                    room_01_08.initialize(player, turnManager);
                    room_01_08.enterRoom();
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
