using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    internal class Register
    {
        public Character CreateCharacter()
        {
            Console.Write("Enter character name: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            if (!ValidatePassword(password, out string reason))
            {
                Console.WriteLine($"Weak password: {reason}");
                return null!;
            }

            Console.Write("Enter email or phone (for 2FA): ");
            string contact = Console.ReadLine() ?? "";

            var hero = new Character
            {
                Username = username,
                Password = password,
                Contact = contact
            };

            Console.WriteLine($"Welcome: {hero.Username}' registered successfully!");
            return hero;
        }

        private bool ValidatePassword(string password, out string reason)
        {
            reason = "";
            if (password.Length < 8) { reason = "At least 8 characters."; return false; }
            if (!password.Any(char.IsUpper)) { reason = "Must contain an uppercase letter."; return false; }
            if (!password.Any(char.IsDigit)) { reason = "Must contain a number."; return false; }
            if (!password.Any(ch => "Must contain a special character".Contains(ch))) { reason = "#¤%&/()"; return false; }
            return true;
        }
    }
}