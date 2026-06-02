using Bork_Dungeon_Crawler_API.Data;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Services
{
    // Handles authentication logic (simple version for local development)
    // This is a temporary version inspired by the old Console login system
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        // REGISTER NEW USER
        public async Task<AppUser?> Register(string username, string password)
        {
            // Check if user already exists
            var existingUser = _context.Users.FirstOrDefault(x => x.Username == username);

            if (existingUser != null)
            {
                // Username already taken
                return null;
            }

            // Create new user (PLAIN TEXT PASSWORD - TEMPORARY)
            var user = new AppUser
            {
                Username = username,
                PasswordHash = password // temporarily used as plain password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // LOGIN USER
        public async Task<AppUser?> Login(string username, string password)
        {
            // Find user
            var user = _context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                // No such user exists
                return null;
            }

            // Direct password comparison (like your old Console system)
            if (user.PasswordHash != password)
            {
                return null;
            }

            return user;
        }
    }
}