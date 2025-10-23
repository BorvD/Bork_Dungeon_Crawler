using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    public class Room_01_04 : BaseRoom
    {
        public override void enterRoom()
        {

            turnManager.checkTurn(() => enterRoom());

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("A small room opens before you — damp, silent, and empty,");
            Console.WriteLine("save for a single rusted chain swaying gently from the ceiling.");
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
                    Room_01_05 nextRoom = new Room_01_05();
                    nextRoom.initialize(player, turnManager);
                    nextRoom.enterRoom();
                    break;
                }
                else if (input == "2")
                {
                    Room_01_01 nextRoom = new Room_01_01();
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
