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
        public void initialize(TestCharacter player, TurnManager turnManager)
        {
            // Referencr till spelare och turhanterare
            this.player = player;
            this.turnManager = turnManager;
        }

        // Abstrakt metod som måste implementeras i alla ärvda rumsklasser
        public abstract void enterRoom();

        protected void checkForOverlay(string input, Action onReturn)
        {
            if (input == "0")
            {
                showOverlayMenu(onReturn);
            }
        }

        private void showOverlayMenu(Action onReturn)
        {
            bool stayInMenu = true;

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

                    case "6":
                        Environment.Exit(0);
                        break;

                    case "0":
                        stayInMenu = false;
                        onReturn?.Invoke();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            }
        }

        private void characterInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Character Info");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Power Level: {player.PowerLevel}");
            Console.WriteLine($"Turns: {player.TurnCounter}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void askAI()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("What the AI will say");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
