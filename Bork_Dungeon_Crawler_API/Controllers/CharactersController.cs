using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bork_Dungeon_Crawler_API.Data;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Controllers
{
    // Markerar att detta är en API-controller
    [ApiController]

    // Bas-route: api/characters
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        // DbContext = kopplingen till databasen
        private readonly AppDbContext _context;

        // Constructor Injection (Dependency Injection)
        // ASP.NET Core skickar in DbContext automatiskt
        public CharactersController(AppDbContext context)
        {
            _context = context;
        }


        // Hämtar alla characters från databasen
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetAll()
        {
            // ToListAsync = hämtar alla rader från tabellen Characters
            return await _context.Characters.ToListAsync();
        }


        // Hämtar en specifik character baserat på ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetById(int id)
        {
            // Letar upp character i databasen
            var character = await _context.Characters.FindAsync(id);

            // Om ingen hittas returnera 404 Not Found
            if (character == null)
                return NotFound();

            // Returnera hittad character
            return character;
        }

        

        // Skapar en ny character i databasen
        [HttpPost]
        public async Task<ActionResult<Character>> Create(Character character)
        {
            // Lägger till ny character i DbContext (men sparas inte än)
            _context.Characters.Add(character);

            // Sparar ändringar till databasen (SQL INSERT)
            await _context.SaveChangesAsync();

            // Returnerar skapad character
            return Ok(character);
        }

        
        
        // Tar bort en character från databasen
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Hitta character i databasen
            var character = await _context.Characters.FindAsync(id);

            // Om den inte finns → 404
            if (character == null)
                return NotFound();

            // Ta bort från DbContext
            _context.Characters.Remove(character);

            // Spara ändringen i databasen (SQL DELETE)
            await _context.SaveChangesAsync();

            // 204 = lyckad borttagning utan content
            return NoContent();
        }
    }
}
