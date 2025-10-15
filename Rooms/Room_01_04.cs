using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_04
    {
        public void room_01_04()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("A small room opens before you — damp, silent, and empty, save for a single rusted chain swaying gently from the ceiling.");
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
                    break;
                }
                else if (input == "2")
                {
                    Room_01_05 room_01_05 = new Room_01_05();
                    room_01_05.room_01_05();
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
