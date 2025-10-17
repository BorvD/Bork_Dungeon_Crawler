using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler
{
    // Character class to store user information
    public class Character
    {
        // Properties for username, password, contact info, and pending 2FA code
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Contact { get; set; } = "";
        public string Pending2FACode { get; set; } = "";
    }
}
