using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    // Main menu for the application
    internal class MainMenu
    {
        // Method to display and handle the main menu
        public void mainMenu()
        {
            // Starts the main menu loop
            Character character = null!;
            // Create instances of Register and Login classes
            var register = new Register();
            // Create an instance of the Login class
            var login = new Login();
            // Main menu loop
            while (true)
            {
                // Display menu options
                Console.WriteLine("1. Register new character");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");
                // Read user choice
                var choice = Console.ReadLine();
                // Switch based on user choice
                switch (choice)
                {
                    // Handle registration
                    case "1":
                        // Call CreateCharacter method to register a new character
                        character = register.CreateCharacter();
                        break;
                    // Handle login
                    case "2":
                        // Call SignIn method to log in with the registered character
                        login.SignIn(character);
                        break;
                    // Handle exit
                    case "3":
                        // Exit the application
                        return;
                    // Handle invalid choice
                    default:
                        // Inform user of invalid choice
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
