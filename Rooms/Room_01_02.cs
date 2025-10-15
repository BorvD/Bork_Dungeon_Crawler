using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_02
    {
        public void room_01_02()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The passage widens briefly into a low alcove. Faded markings cover the walls, their meaning long forgotten.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Go East.");
            Console.WriteLine("2. Go West.");
            string input = Console.ReadLine();

            while (true)
            { 
                 if (input == "1")
                {
                    Room_01_01 room_01_01 = new Room_01_01();
                    room_01_01.room_01_01();
                }
                    else if (input == "2")
                {
                    Room_01_03 room_01_03 = new Room_01_03();
                    room_01_03.room_01_03();
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
