using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    internal class Register
    {
        public Character createCharacter()
        {
            // Ask user to enter a character name
            Console.Write("Enter character name: ");
            string username = Console.ReadLine();

            // Ask user to enter a password
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Check if password meets requirements
            if (!validatePassword(password, out string reason))
            {
                // If password is does not meet the requierments
                Console.WriteLine($"Weak password: {reason}");
                return null;
            }

            // Ask user to enter email or phone number for 2FA
            Console.Write("Enter email or phone (for 2FA): ");
            string contact = Console.ReadLine();

            // Create a new character object with entered details
            var character = new Character
            {
                Username = username,
                Password = password,
                Contact = contact
            };

            // Confirm successful registration
            Console.WriteLine($"Welcome, {character.Username}! Registered successfully.");
            return character; // Return the new character
        }

        // Checks that password follows the rules
        private bool validatePassword(string password, out string reason)
        {
            reason = ""; // Default reason is empty

            // Check for minimum length
            if (password.Length < 4)
            {
                reason = "At least 4 characters required.";
                return false;
            }

            // Check for uppercase letter ! Flips true false
            if (!password.Any(char.IsUpper))
            {
                reason = "Must contain an uppercase letter.";
                return false;
            }

            // Check for number
            if (!password.Any(char.IsDigit))
            {
                reason = "Must contain a number.";
                return false;
            }

            // Check for at least one special character
            if (!password.Any(ch => "!#¤%&".Contains(ch)))
            {
                reason = "Must contain a special character.";
                return false;
            }

            // If all checks passed, password is valid
            return true;
        }
    }
}