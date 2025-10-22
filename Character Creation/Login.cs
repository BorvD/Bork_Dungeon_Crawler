using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{

    internal class Login
    {
        // Method for signing in an existing character with simple 2FA check
        public void signIn(Character character)
        {
            // Check if a character has been registered first
            if (character == null)
            {
                Console.WriteLine("No character found!");
                return; // Exit if there’s no character to log in
            }

            // Ask user for character name
            Console.Write("Enter character name: ");
            string name = Console.ReadLine();

            // Ask user for password
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Check if entered name and password match the saved character
            if (name != character.Username || password != character.Password)
            {
                Console.WriteLine("Incorrect character name or password!");
                return; // Stop if login info is wrong
            }

            // Generate a random 2FA code for extra verification
            character.Pending2FACode = generate2FACode();

            // Simulate sending the code to the user's contact info
            Console.WriteLine($"(2FA code sent to {character.Contact})");

            // For testing: show the 2FA code directly in console
            Console.WriteLine($"Enter 2FA code: {character.Pending2FACode}");

            // Ask user to type in the 2FA code
            Console.Write("Enter 2FA code: ");
            string entered = Console.ReadLine();

            // Compare the entered code with the generated one
            if (entered == character.Pending2FACode)
            {
                // Login successful
                Console.WriteLine($"Welcome, {character.Username}!");
                // Clear the code once used
                character.Pending2FACode = "";
            }
            else
            {
                // 2FA failed
                Console.WriteLine("Wrong 2FA code!");
            }
        }

        // Method that creates a random 6-digit code for 2FA
        private string generate2FACode()
        {
            var rnd = new Random();
            // Random number between 100000–999999 (6 digits)
            return rnd.Next(100000, 999999).ToString();
        }
    }
}