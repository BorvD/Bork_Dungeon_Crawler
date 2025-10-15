using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_03
    {
        public void room_01_03()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The corridor opens into a cramped chamber.");
            Console.WriteLine("A foul stench hangs heavy in the air.");
            Console.WriteLine();
            Console.WriteLine("There — crouched beside a torn corpse — an imp giggles, tugging at the body's arm like a child with a broken doll.");
            Console.WriteLine("Its claws are slick with blood, its eyes glowing faintly in the dark.");
            Console.WriteLine();
            Console.WriteLine("When it sees you, the grin widens.");
            Console.WriteLine("It hisses — low, eager — and the plaything drops to the floor with a wet thud.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Attack.");
                Console.WriteLine("2. Run.");
                Console.WriteLine("3. Search Room.");
                string input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Can not be done!");
                    return;
                }
                else if (input == "1")
                {
                    // Combat sequence would go here
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You lunge at the imp, weapon raised...");
                    // Placeholder for combat outcome
                    Console.WriteLine("After a fierce battle, you emerge victorious, the imp lies defeated.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (input == "2")
                {
                    // Sneaking sequence would go here
                    Console.WriteLine("You run away back from where you came");
                    Room_01_02 room_01_02 = new Room_01_02();
                    room_01_02.room_01_02();
                    break;
                }
                else if (input == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("When the room finally falls silent, you take a careful look around.");
                    Console.WriteLine("The stench of blood still lingers, but beneath a pile of debris, something catches the light.");
                    Console.WriteLine();
                    Console.WriteLine("You pull it free — a shield, battered but still solid.");
                    Console.WriteLine("The crest upon it is worn beyond recognition, yet holding it feels... right. Safer.");
                    Console.WriteLine();
                    Console.WriteLine("Maybe its last owner didn't make it out — but you might.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else
                {
                    Console.WriteLine("Can not be done!");
                    Console.WriteLine();
                    return;
                }
            }
        }
    }
}
