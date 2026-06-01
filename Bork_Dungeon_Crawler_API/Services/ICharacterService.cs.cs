using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Services
{
    // Den säger: "alla services som implementerar detta MÅSTE ha dessa metoder"
    // Det gör koden mer flexibel och lättare att byta ut senare
    public interface ICharacterService
    {
        // Hämtar alla characters från databasen
        Task<List<Character>> GetAll();

        // Hämtar en specifik character baserat på id
        Task<Character?> GetById(int id);

        // Skapar en ny character och returnerar den skapade objektet
        Task<Character> Create(Character character);

        // Tar bort en character och returnerar true/false beroende på om det lyckades
        Task<bool> Delete(int id);
    }
}
