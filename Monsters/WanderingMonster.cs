using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Monsters
{
    internal class WanderingMonster
    {
        private List<Monster> monsters = new List<Monster>();

        public WanderingMonster()
        {
            monsters.Add(new Monster("Zombie", "A brutish warrior that loves battle.", 2));
            monsters.Add(new Monster("Specter", "A ghostly figure that drains life energy.", 3));
            monsters.Add(new Monster("Imp", "A mischievous fire demon, small but dangerous.", 1));
        }

        public void ShowAllMonsters()
        {
            Console.WriteLine("Wandering Monsters:");
            Console.WriteLine("-------------------");
            foreach (var monster in monsters)
            {
                monster.DisplayInfo();
            }
        }

        public Monster GetRandomMonster()
        {
            Random rand = new Random();
            int index = rand.Next(monsters.Count);
            return monsters[index];
        }

        public void StartEncounter()
        {
            ShowAllMonsters();

            Console.WriteLine("A random monster appears!");
            Monster random = GetRandomMonster();
            random.DisplayInfo();
        }
    }
}
