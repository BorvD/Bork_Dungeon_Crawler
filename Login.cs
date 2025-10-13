using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    internal class Login
    {
        public void SignIn(Character character)
        {
            if (character == null)
            {
                Console.WriteLine("No character found!");
                return;
            }

            Console.Write("Enter character name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            if (name != character.Username || password != character.Password)
            {
                Console.WriteLine("Incorrect character name name or password!");
                return;
            }

            // Generate 2FA code
            character.Pending2FACode = Generate2FACode();

            Console.WriteLine($"(2FA code sent to {character.Contact})");
            Console.WriteLine($"Enter 2FA code: {character.Pending2FACode}]");

            Console.Write("Enter 2FA code: ");
            string entered = Console.ReadLine() ?? "";

            if (entered == character.Pending2FACode)
            {
                Console.WriteLine($"Welcome, {character.Username}!");
                character.Pending2FACode = "";
            }
            else
            {
                Console.WriteLine("Wrong 2FA code!");
            }
        }

        private string Generate2FACode()
        {
            var rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }
    }
}