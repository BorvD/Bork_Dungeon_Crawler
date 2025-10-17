using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    
    internal class Login
    {
        // Method to handle user sign-in with 2FA
        public void SignIn(Character character)
        {
            // if statement to check if character is null
            if (character == null)
            {
                // Print message and return if no character is found
                Console.WriteLine("No character found!");
                return;
            }

            // Asks for character
            Console.Write("Enter character name: ");
            // Read character name from console
            string name = Console.ReadLine() ?? "";

            // Asks for password
            Console.Write("Enter password: ");
            // Read password from console
            string password = Console.ReadLine() ?? "";

            // Validate name and password
            if (name != character.Username || password != character.Password)
            {
                // Print error message for incorrect credentials
                Console.WriteLine("Incorrect character name name or password!");
                return;
            }

            // Generate 2FA code
            character.Pending2FACode = Generate2FACode();

            // Simulate sending 2FA code to contact
            Console.WriteLine($"(2FA code sent to {character.Contact})");
            // Shows the 2FA code in the console that the user should enter
            Console.WriteLine($"Enter 2FA code: {character.Pending2FACode}]");

            //Asks for 2FA code
            Console.Write("Enter 2FA code: ");
            // Read 2FA code from console
            string entered = Console.ReadLine() ?? "";

            // Validate 2FA code
            if (entered == character.Pending2FACode)
            {
                // Print welcome message on successful login
                Console.WriteLine($"Welcome, {character.Username}!");
                character.Pending2FACode = "";
            }
            // Handle incorrect 2FA code
            else
            {
                // Print error message for wrong 2FA code
                Console.WriteLine("Wrong 2FA code!");
            }
        }

        // Method to generate a random 2FA code
        private string Generate2FACode()
        {
            // Generate a random 6-digit code
            var rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }
    }
}