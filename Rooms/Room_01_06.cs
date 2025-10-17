using Bork_Dungeon_Crawler.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    public class Room_01_06 : BaseRoom
    {
        public override void enterRoom()
        {
            turnManager?.checkTurn(() => enterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You enter a narrow chamber cluttered with broken crates and cobwebs. Nothing stirs but the dust.");
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
                    Room_01_07 room_01_07 = new Room_01_07();
                    room_01_07.initialize(player, turnManager);
                    room_01_07.enterRoom();
                    break;
                }
                else if (input == "2")
                {
                    Room_01_01 room_01_01 = new Room_01_01();
                    room_01_01.initialize(player, turnManager);
                    room_01_01.enterRoom();
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
