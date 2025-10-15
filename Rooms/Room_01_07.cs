using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_07
    {
        public void room_01_07()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The room is small and bare, save for a single torch still burning low — someone has been here recently.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Go South.");
            Console.WriteLine("2. Go North.");
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "1")
                {
                    Room_01_08 room_01_08 = new Room_01_08();
                    room_01_08.room_01_08();
                    break;
                }
                else if (input == "2")
                {
                    Room_01_06 room_01_06 = new Room_01_06();
                    room_01_06.room_01_06();
                    break;
                }
                else
                {
                    Console.WriteLine("Can not be done!");
                    return;
                }
            }
        }
    }
}
