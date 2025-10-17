using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_11 : BaseRoom
    {
        public override void EnterRoom()
        {
            turnManager?.CheckTurn(() => EnterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The room beyond is small and cramped — shelves line the walls, stacked with broken plates and moldy bread.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Go East.");
            Console.WriteLine("2. Go West.");
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "1")
                {
                    Room_01_12 room_01_12 = new Room_01_12();
                    room_01_12.Initialize(player, turnManager);
                    room_01_12.EnterRoom();
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
                    return;
                }
            }
        }
    }
}
