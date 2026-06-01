using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_10 : BaseRoom
    {
        public override void enterRoom()
        {

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You step into the sleeping quarters.");
            Console.WriteLine("The air is thick with the scent of sweat, metal, and death — still recent.");
            Console.WriteLine();
            Console.WriteLine("Rows of beds line the walls, sheets torn and darkened with old stains.");
            Console.WriteLine("Beside one bed lies a body clad in armor, slumped against the wall.");
            Console.WriteLine("No weapon. No shield. Just the dull gleam of steel and a lifeless stare.");
            Console.WriteLine();
            Console.WriteLine("The armor bears fresh dents and scratches, as if struck only moments ago.");
            Console.WriteLine("A thin trail of blood runs from beneath the plates, pooling on the floor.");
            Console.WriteLine();
            Console.WriteLine("Whoever they were, they didn’t fall long ago...");
            Console.WriteLine("and whatever killed them might still be close.");
            Console.WriteLine();
            Console.WriteLine("You take a step closer. The air feels heavier.");
            Console.WriteLine("Then — a sound.");
            Console.WriteLine();
            Console.WriteLine("A faint, wet gasp escapes the corpse’s lips.");
            Console.WriteLine("Fingers twitch against the floor, the sound of metal scraping stone echoing through the room.");
            Console.WriteLine("The body jerks once, then again —");
            Console.WriteLine("and with a slow, grinding motion, it begins to rise.");
            Console.WriteLine();
            Console.WriteLine("The head tilts upward. Eyes once empty now burn with a dull, sickly light.");
            Console.WriteLine("The dead man stands before you, swaying slightly,");
            Console.WriteLine("armor clinking in rhythm with each hollow breath.");
            Console.WriteLine();
            Console.WriteLine("Death has let him go too soon.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Attack.");
                Console.WriteLine("2. Run.");
                Console.WriteLine("3. Search Room.");
                string input = Console.ReadLine();

                checkForOverlay(input, () => enterRoom());

                if (input == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You strike at the undead warrior!");
                    Console.WriteLine("After a fierce battle, you emerge victorious, the undead warrior lies defeated again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (input == "2")
                {
                    Console.WriteLine("You run away back from where you came");
                    Room_01_09 room_01_09 = new Room_01_09();
                    room_01_09.initialize(player, turnManager);
                    room_01_09.enterRoom();
                    break;
                }
                else if (input == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The room is silent again.");
                    Console.WriteLine("Only the faint drip of water and the soft creak of old wood break the stillness.");
                    Console.WriteLine();
                    Console.WriteLine("You glance around — broken beds, torn sheets, and walls scarred by age and struggle.");
                    Console.WriteLine("The air smells of iron and dust.");
                    Console.WriteLine("What was once a place of rest now feels more like a tomb.");
                    Console.WriteLine();
                    Console.WriteLine("Your eyes fall on the fallen undead.");
                    Console.WriteLine("Its armor, though dented and bloodied, is in far better shape than yours.");
                    Console.WriteLine("The metal bears strange markings — symbols you don’t recognize —");
                    Console.WriteLine("but it’s solid, well-forged, and heavy with history.");
                    Console.WriteLine();
                    Console.WriteLine("You kneel beside the body and unbuckle the plates.");
                    Console.WriteLine("They come free with a groan of worn leather and dried blood.");
                    Console.WriteLine("When you fasten them around yourself, the fit is almost perfect.");
                    Console.WriteLine();
                    Console.WriteLine("The weight settles on your shoulders —");
                    Console.WriteLine("not just the metal, but the memory of the one who wore it before you.");
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
