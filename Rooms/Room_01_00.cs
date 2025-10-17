using Bork_Dungeon_Crawler.Monsters;
using Bork_Dungeon_Crawler.Rooms;
using System;
using System.Numerics;

public class Room_01_00 : BaseRoom
{
    public override void EnterRoom()
    {

        turnManager.CheckTurn(() => EnterRoom());

        Console.Clear();
        Console.WriteLine("------------------------------------------------------");
         Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("The stone steps groan beneath your boots as you descend...");
        Console.WriteLine("Each one feels colder than the last, slick with moisture from the depths below.");
        Console.WriteLine("At the bottom waits a heavy iron door — its surface scarred by claws or time.");
        Console.WriteLine("You push it open.");
        Console.WriteLine();
        Console.WriteLine("The hinges scream as stale, ancient air escapes into the corridor behind you.");
        Console.WriteLine("Inside, a single torch flickers, fighting the darkness that presses in from every wall.");
        Console.WriteLine("Chains hang from the ceiling like forgotten prayers.");
        Console.WriteLine();
        Console.WriteLine("Somewhere far off, a drip echoes... once... twice... then silence.");
        Console.WriteLine();
        Console.WriteLine("> The dungeon has accepted you.");
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
                Room_01_01 room0101 = new Room_01_01();
                room0101.Initialize(player, turnManager);
                room0101.EnterRoom();
                break;
            }
            else if (input == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You glance back at the stairs...");
                Console.WriteLine("The faint light from above barely touches the bottom step now — a reminder of the world you left behind.");
                Console.WriteLine("For a moment, you feel the pull of safety...");
                Console.WriteLine("But then you shake your head.");
                Console.WriteLine("That’s not the way forward. Only a coward climbs back to the light.");
                Console.WriteLine();
                Console.WriteLine("You turn from the stairs and face the waiting dark.");
                Console.WriteLine("Somewhere ahead, the dungeon breathes.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------------------------");
                continue;
            }
            else
            {
                Console.WriteLine("Can not be done.");
                continue;
            }
        }
    }
}
