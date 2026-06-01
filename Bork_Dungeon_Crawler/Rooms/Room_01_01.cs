using Bork_Dungeon_Crawler.Monsters;
using Bork_Dungeon_Crawler.Rooms;
using System;
using System.Numerics;

public class Room_01_01 : BaseRoom
{
    // Skriver över EnterRoom-metoden för detta specifika rum
    public override void enterRoom()
    {
        // Anropar TurnManager för att kolla om wandering monster skall triggas (Använder Action och Invoke för att hitta rätt)
        turnManager.checkTurn(() => enterRoom());

        // Rummets beskrivning
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You step through the doorway and into a long, shadow-drenched hall.");
        Console.WriteLine("Broken furniture litters the floor — tables split in half, chairs overturned, scorch marks staining the stone.");
        Console.WriteLine("The air smells faintly of smoke and blood.");
        Console.WriteLine();
        Console.WriteLine("Something terrible happened here... and not long ago.");
        Console.WriteLine();
        Console.WriteLine("Deep gouges run along the walls, as if some great beast had torn through the room in fury.");
        Console.WriteLine("A shattered sword lies beside a dented helm, both slick with fresh rust.");
        Console.WriteLine();
        Console.WriteLine("You kneel and touch the ground — it’s still warm.");
        Console.WriteLine("Whatever fought here, whatever died here... it might still be close.");
        Console.ForegroundColor = ConsoleColor.White;

        // En while-loop för att hantera spelarens val i rummet
        while (true)
        {
            // Frågar spelaren vilket val de vill göra
            Console.WriteLine();
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Go South.");
            Console.WriteLine("2. Go North.");
            Console.WriteLine("3. Go East.");
            Console.WriteLine("4. Go West.");
            Console.WriteLine("5. Search Room"); 
            string input = Console.ReadLine();

            checkForOverlay(input, () => enterRoom());

            if (input == "1")
            {
                Room_01_06 room0106 = new Room_01_06();
                room0106.initialize(player, turnManager);
                room0106.enterRoom();
                break;
            }
            else if (input == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("The door has locked behind you. Only way is forward!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input == "3")
            {

                Room_01_04 room0104 = new Room_01_04();
                room0104.initialize(player, turnManager);
                room0104.enterRoom();
                break;
            }
            else if (input == "4")
            {

                Room_01_02 room0102 = new Room_01_02();
                room0102.initialize(player, turnManager);
                room0102.enterRoom();
                break;
            }
            else if (input == "5")
            {
                Console.WriteLine("You notice dark streaks along the cracked floor.");
                Console.WriteLine("Blood — thick and still wet in places — smeared by desperate hands.");
                Console.WriteLine();
                Console.WriteLine("It leads away from the hall in two directions:");
                Console.WriteLine("One trail disappearing into the east corridor, the other vanishing down the west passage.");
                Console.WriteLine();
                Console.WriteLine("Whoever fought here... someone survived. Or something did.");
            }
            else
            {
                Console.WriteLine("Can not be done!");
                Console.WriteLine();
            }
        }
    }
}