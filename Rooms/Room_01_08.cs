using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_08
    {
        public void room_01_08() 
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You step into what was once a grand dining hall.");
            Console.WriteLine("Long tables stretch across the room, now overturned and splintered.");
            Console.WriteLine("Silver goblets lie scattered on the floor, their shine dulled beneath a layer of dust and dried blood.");
            Console.WriteLine();
            Console.WriteLine("Tattered banners hang from the walls, their emblems faded and torn.");
            Console.WriteLine("The scent of rot mixes with something faintly sweet — spoiled wine pooling beneath the remains of a shattered cask.");
            Console.WriteLine();
            Console.WriteLine("Several chairs are still upright, gathered near the head of the table as though waiting for guests who never arrived.");
            Console.WriteLine("A single candle burns weakly in a brass holder, its wax long melted down the stem.");
            Console.WriteLine();
            Console.WriteLine("Somewhere among the wreckage, you think you hear the soft clink of metal — a sound too steady to be the wind.");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Go South.");
            Console.WriteLine("2. Go North.");
            Console.WriteLine("3. Go East.");
            Console.WriteLine("4. Go West.");
            Console.WriteLine("5. Search Room");
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "1")
                {                     
                    Room_01_13 room_01_13 = new Room_01_13();
                    room_01_13.room_01_13();
                }
                else if (input == "2")
                {
                    Room_01_07 room_01_07 = new Room_01_07();
                    room_01_07.room_01_07();
                }
                else if (input == "3")
                {
                    Room_01_11 room_01_11 = new Room_01_11();
                    room_01_11.room_01_11();
                }
                else if (input == "4")
                {
                    Room_01_09 room_01_09 = new Room_01_09();
                    room_01_09.room_01_09();
                }
                else if (input == "5")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You move carefully through the wreckage, brushing aside shattered plates and splintered wood.");
                    Console.WriteLine("The air is heavy with dust and old smoke.");
                    Console.WriteLine();
                    Console.WriteLine("To the east, an open archway reveals rows of hanging pots and cold hearths — the kitchen.");
                    Console.WriteLine("To the west, a darker corridor stretches away, lined with doorways and tattered curtains — the sleeping quarters.");
                    Console.WriteLine();
                    Console.WriteLine("Wherever you go next, the silence feels like it's watching... and waiting.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("------------------------------------------------------");
                    return;
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
