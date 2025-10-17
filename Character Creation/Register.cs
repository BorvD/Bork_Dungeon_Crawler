using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    internal class Register
    {
        // Method to create a new character with validation
        public Character CreateCharacter()
        {
            // Asks for character name
            Console.Write("Enter character name: ");
            // Read character name from console
            string username = Console.ReadLine() ?? "";

            // Asks for password
            Console.Write("Enter password: ");
            // Read password from console
            string password = Console.ReadLine() ?? "";

            // Validate password strength
            if (!ValidatePassword(password, out string reason))
            {
                // Print reason for weak password
                Console.WriteLine($"Weak password: {reason}");
                return null!;
            }

            // Asks for email or phone for 2FA
            Console.Write("Enter email or phone (for 2FA): ");
            // Read contact info from console
            string contact = Console.ReadLine() ?? "";

            // Create and return new character
            var character = new Character
            {
                // Set properties for the new character
                Username = username,
                Password = password,
                Contact = contact
            };

            // Print success message
            Console.WriteLine($"Welcome: {character.Username}' registered successfully!");
            // Return the created character
            return character;
        }

        // Method to validate password strength
        private bool ValidatePassword(string password, out string reason)
        {
            // Initialize reason as empty
            reason = "";
            // Check password length
            if (password.Length < 8) 
            {
                // Need at least 8 characters
                reason = "At least 8 characters."; return false; 
            }
            // Check for uppercase letter
            if (!password.Any(char.IsUpper)) 
            {
                // Need at least one uppercase letter
                reason = "Must contain an uppercase letter."; return false; 
            }
            // Check for digit
            if (!password.Any(char.IsDigit)) 
            {
                // Need at least one number
                reason = "Must contain a number."; return false; 
            }
            // Check for special character
            if (!password.Any(ch => "Must contain a special character".Contains(ch))) 
            {
                // Need at least one special character
                reason = "#¤%&/()"; return false; 
            }
            // Password is strong
            return true;
        }
    }
}