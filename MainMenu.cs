using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    internal class MainMenu
    {
        public void mainMenu()
        {
            Character character = null!;
            var register = new Register();
            var login = new Login();
            while (true)
            {
                Console.WriteLine("1. Register new character");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        character = register.CreateCharacter();
                        break;
                    case "2":
                        login.SignIn(character);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
