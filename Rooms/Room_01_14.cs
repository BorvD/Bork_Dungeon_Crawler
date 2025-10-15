using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_14
    {
        public void room_01_14()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The hallway ends at a heavy iron door, dark with rust and scorched by fire.");
            Console.WriteLine("Strange runes are carved along its edges, faintly glowing in the gloom.");
            Console.WriteLine("Whatever lies beyond, it was meant to stay locked — or protected.");
            Console.WriteLine();
            Console.WriteLine("Four small figures crouch before it, their twisted shapes flickering in the torchlight.");
            Console.WriteLine("Imps.");
            Console.WriteLine("They hiss and bicker among themselves, scratching at the metal and guarding it like dogs over a bone.");
            Console.WriteLine();
            Console.WriteLine("One notices you first.");
            Console.WriteLine("Its head jerks up, yellow eyes narrowing, and a shrill cry cuts through the air.");
            Console.WriteLine("The others snap to attention, wings fluttering, claws scraping stone.");
            Console.WriteLine();
            Console.WriteLine("The smallest scurries toward the shadows,");
            Console.WriteLine("while the largest steps forward — grinning, teeth glinting in the dim light.");
            Console.WriteLine();
            Console.WriteLine("The iron door stands behind them, unmoving and silent.");
            Console.WriteLine("If you want to reach it...");
            Console.WriteLine("you’ll have to get through them first.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Attack.");
                Console.WriteLine("2. Run.");
                Console.WriteLine("3. Search Room.");
                Console.WriteLine("4. Unlock the door");
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
                    Console.WriteLine("You strike at the undead warrior!");
                    // Placeholder for combat outcome
                    Console.WriteLine("After a fierce battle, you emerge victorious, the undead warrior lies defeated again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (input == "2")
                {
                    // Sneaking sequence would go here
                    Console.WriteLine("You run away back from where you came");
                    Room_01_13 room_01_13 = new Room_01_13();
                    room_01_13.room_01_13();
                    break;
                }
                else if (input == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("When the last imp falls silent, the room is still again.");
                    Console.WriteLine("Only the faint crackle of torches remains — and the low hum of the runes on the iron door.");
                    Console.WriteLine();
                    Console.WriteLine("You search the chamber carefully.");
                    Console.WriteLine("Broken chains lie near the walls, claw marks gouged deep into the stone.");
                    Console.WriteLine("A few scraps of leather, burned paper, and imp blood are all that remain of the fight.");
                    Console.WriteLine();
                    Console.WriteLine("Your eyes settle on the door.");
                    Console.WriteLine("Thick iron. Reinforced. Ancient.");
                    Console.WriteLine("You try the handle — it doesn’t move.");
                    Console.WriteLine("Locked tight.");
                    Console.WriteLine();
                    Console.WriteLine("Whatever’s beyond this door...");
                    Console.WriteLine("wasn’t meant to be opened easily.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (input == "4")
                {
                    Epilogue epilogue = new Epilogue();
                    epilogue.epilogue();
                    break;
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
