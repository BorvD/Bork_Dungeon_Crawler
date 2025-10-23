using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    internal class Room_01_12 : BaseRoom
    {
        public override void enterRoom()
        {

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You step into what was once a kitchen.");
            Console.WriteLine("The air is thick with smoke and the sour stench of spoiled food.");
            Console.WriteLine();
            Console.WriteLine("Broken pots and shattered dishes litter the floor.");
            Console.WriteLine("A long table lies overturned, and scorch marks crawl up the stone walls.");
            Console.WriteLine("Something still smolders in the hearth, giving off a faint, sickly glow.");
            Console.WriteLine();
            Console.WriteLine("Then you hear movement — quick, scraping, and sharp.");
            Console.WriteLine("From behind a toppled shelf, a small red creature darts out, grinning with needle teeth.");
            Console.WriteLine("Another follows, hissing as it claws at the floor.");
            Console.WriteLine("A third perches on the counter, swinging a cleaver that’s far too big for its tiny hands.");
            Console.WriteLine();
            Console.WriteLine("Three imps.");
            Console.WriteLine("Their yellow eyes glint with mischief and hunger as they watch you enter.");
            Console.WriteLine("The largest of them tilts its head and lets out a dry, crackling laugh.");
            Console.WriteLine();
            Console.WriteLine("Dinner, it seems, isn’t quite over.");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Attack.");
                Console.WriteLine("2. Run.");
                Console.WriteLine("3. Search Room.");
                string input = Console.ReadLine();

                checkForOverlay(input, () => enterRoom());

                if (input == null)
                {
                    Console.WriteLine("Can not be done!");
                    return;
                }
                else if (input == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You strike at the imps");
                    Console.WriteLine("After a brief skirmish, you manage to defeat the imps, leaving them sprawled on the floor, twitching.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (input == "2")
                {
                    Console.WriteLine("You run away back from where you came");
                    Room_01_11 room_01_11 = new Room_01_11();
                    room_01_11.initialize(player, turnManager);
                    room_01_11.enterRoom();
                    break;
                }
                else if (input == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("When the last echo of the imps’ shrieks fades,");
                    Console.WriteLine("the kitchen falls into uneasy silence once more.");
                    Console.WriteLine();
                    Console.WriteLine("You take a moment to look around.");
                    Console.WriteLine("Broken plates crunch beneath your boots. The air still smells of smoke and rot.");
                    Console.WriteLine();
                    Console.WriteLine("On one of the counters, half-buried beneath a pile of burnt rags,");
                    Console.WriteLine("something glints faintly in the dim light.");
                    Console.WriteLine();
                    Console.WriteLine("You brush the ash aside and find a small iron key —");
                    Console.WriteLine("old, cold to the touch, its teeth worn smooth with age.");
                    Console.WriteLine("A faint marking runs along its side, too faded to read.");
                    Console.WriteLine();
                    Console.WriteLine("Whatever it once opened,");
                    Console.WriteLine("you can only hope it still does.");
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
