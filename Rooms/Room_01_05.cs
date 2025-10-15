using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_05
    {
        public void room_01_05()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You open a narrow door leading into a cramped side room.");
            Console.WriteLine("The air is warm and smells faintly of sulfur and burnt wood.");
            Console.WriteLine();
            Console.WriteLine("The space is small — barely enough to stand in.");
            Console.WriteLine("Shelves line the walls, stacked with broken jars, rusted utensils, and shards of glass.");
            Console.WriteLine("Something scurries behind a barrel, knocking it over with a hollow thud.");
            Console.WriteLine();
            Console.WriteLine("A small imp tumbles into view.");
            Console.WriteLine("It’s smaller than the others — thin, jittery, with soot-streaked skin and wide, yellow eyes.");
            Console.WriteLine("For a moment, it just stares at you, clutching a cracked ladle like a weapon.");
            Console.WriteLine();
            Console.WriteLine("Then it lets out a nervous hiss and backs into a corner,");
            Console.WriteLine("growling in a trembling voice that’s more fear than fury.");
            Console.WriteLine();
            Console.WriteLine("You can almost tell — this one wasn’t made for fighting.");
            Console.WriteLine("Just left behind.");
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
                    Console.WriteLine("You strike at the little imp!");
                    // Placeholder for combat outcome
                    Console.WriteLine("After a brief struggle, you manage to subdue the imp. It collapses to the ground, whimpering softly.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (input == "2")
                {
                    // Sneaking sequence would go here
                    Console.WriteLine("You run away back from where you came");
                    Room_01_04 room_01_04 = new Room_01_04();
                    room_01_04.room_01_04();
                    break;
                }
                else if (input == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("When the scuffling and hiss of the little imp fade into silence,");
                    Console.WriteLine("you take a careful look around the cramped room.");
                    Console.WriteLine();
                    Console.WriteLine("Dust coats everything.");
                    Console.WriteLine("Broken shelves lean against the wall, and shattered jars crunch underfoot.");
                    Console.WriteLine("Among the debris lies a glint of metal — half-buried beneath a pile of torn cloth.");
                    Console.WriteLine();
                    Console.WriteLine("You pull it free.");
                    Console.WriteLine("A short sword, dull with grime but balanced and solid.");
                    Console.WriteLine("Its edge is chipped, yet the weight feels right in your hand.");
                    Console.WriteLine();
                    Console.WriteLine("Someone once fought with this —");
                    Console.WriteLine("and with a little care, it might serve you just as well.");
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
