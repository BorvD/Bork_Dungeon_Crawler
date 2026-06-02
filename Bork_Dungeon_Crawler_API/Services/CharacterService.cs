using Microsoft.EntityFrameworkCore;
using Bork_Dungeon_Crawler_API.Data;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Services
{
    // Denna klass innehåller all logik för Characters
    // Den pratar med databasen via DbContext
    public class CharacterService : ICharacterService
    {
        // DbContext = kopplingen till SQL-databasen
        private readonly AppDbContext _context;

        // Constructor Injection (Dependency Injection)
        // ASP.NET Core skickar in DbContext automatiskt
        public CharacterService(AppDbContext context)
        {
            _context = context;
        }

        // HÄMTA ALLA CHARACTERS
        public async Task<List<Character>> GetAll()
        {
            // Hämtar alla rader från Characters-tabellen
            return await _context.Characters.ToListAsync();
        }

        // HÄMTA EN CHARACTER
        public async Task<Character?> GetById(int id)
        {
            // FindAsync letar direkt på Primary Key (Id)
            return await _context.Characters.FindAsync(id);
        }

        // SKAPA NY CHARACTER
        public async Task<Character> Create(Character character)
        {
            // Lägger till objekt i EF Core tracking system
            // (inget sparas i databasen ännu)
            _context.Characters.Add(character);

            // Utför SQL INSERT i databasen
            await _context.SaveChangesAsync();

            // Returnerar den skapade charactern
            return character;
        }

        // Skapar karaktär kopplad till User
        public async Task<Character> CreateForUser(int userId, string username)
        {
            var character = new Character
            {
                Username = username,
                UserId = userId,
                PowerLevel = 1,
                TurnCounter = 0,
                CreatedAt = DateTime.UtcNow,
                CurrentRoomId = 100
            };

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return character;
        }

        // TA BORT CHARACTE
        public async Task<bool> Delete(int id)
        {
            // Försök hitta character i databasen
            var character = await _context.Characters.FindAsync(id);

            // Om den inte finns → misslyckas
            if (character == null)
                return false;

            // Markera för borttagning
            _context.Characters.Remove(character);

            // Utför SQL DELETE
            await _context.SaveChangesAsync();

            // Bekräfta att det lyckades
            return true;
        }
        // Visa alla karaktärer som tillhör inloggad user
        public async Task<List<Character>> GetByUserId(int userId)
        {
            return await _context.Characters
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}