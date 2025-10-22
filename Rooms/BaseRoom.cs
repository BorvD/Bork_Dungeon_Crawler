using Bork_Dungeon_Crawler.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    // Abstrakt bas rum där alla andra rum ärver ifrån
    public abstract class BaseRoom
    {
        // Referenser till spelarkaraktären och turhanteraren
        protected TestCharacter player;
        protected TurnManager turnManager;

        //Metod för att starta rummet med spelare och turhanterare
        public void initialize(TestCharacter pla, TurnManager tM)
        {
            // Referencr till spelare och turhanterare
            player = pla;
            turnManager = tM;
        }

        // Abstrakt metod som måste implementeras i alla ärvda rumsklasser
        public abstract void enterRoom();

        // Metod som startar overlay om man trycker på 0
        protected void checkForOverlay(string input, Action onReturn)
        {
            if (input == "0")
            {
                // Startar metoden show overlay
                showOverlayMenu(onReturn);
            }
        }

        // Metod för overlay, använder action för att skapa en kortlek där senaste försvinner
        private void showOverlayMenu(Action onReturn)
        {
            // Menyn  finns så länge den är true (while loop som är sann)
            bool stayInMenu = true;

            // WHile loop som styr vilken del av menyn man vill in på
            while (stayInMenu)
            {

                Console.WriteLine("1. Check character");
                Console.WriteLine("2. Ask AI");
                Console.WriteLine("6. Exit game");
                Console.WriteLine("0. Return to game");

                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        characterInfo();
                        break;

                    case "2":
                        askAI();
                        break;
                     // Avslutar spelet
                    case "6":
                        Environment.Exit(0);
                        break;

                        // ändrar whileloopen till falsk och återgår till rummet som fanns innan
                    case "0":
                        stayInMenu = false;
                        onReturn.Invoke();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            }
        }


        // det som vissas i meny 1
        private void characterInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Character Info");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Power Level: {player.PowerLevel}");
            Console.WriteLine($"Turns: {player.TurnCounter}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // det som vissas i meny 2
        private void askAI()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("What the AI will say");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
