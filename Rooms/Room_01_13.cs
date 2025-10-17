using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_13 : BaseRoom
    {
        public override void EnterRoom()
        {
            turnManager?.CheckTurn(() => EnterRoom());

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

                if (input == "1")
                {
                    Room_01_14 room_01_14 = new Room_01_14();
                    room_01_14.Initialize(player, turnManager);
                    room_01_14.EnterRoom();
                    break;
                }
                else if (input == "2")
                {
                    Room_01_08 room_01_08 = new Room_01_08();
                    room_01_08.Initialize(player, turnManager);
                    room_01_08.EnterRoom();
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
