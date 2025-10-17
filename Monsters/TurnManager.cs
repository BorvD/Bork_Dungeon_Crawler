using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Monsters
{
    
    public class TurnManager
    {
        // Hämtar informatipn Character och WanderingMonster
        private TestCharacter player;
        private WanderingMonster wanderingMonster;

        // Konstruktor för TurnManager som tar emot en TestCharacter och en WanderingMonster
        public TurnManager(TestCharacter player, WanderingMonster wanderingMonster)
        {
            // Sätter de privata fälten till de mottagna objekten
            this.player = player;
            this.wanderingMonster = wanderingMonster;
        }

        // Metod för att kolla om en vandrande monster-encounter ska triggas baserat på spelarens tur-räknare
        public void CheckTurn(Action resumeRoom)
        {
            // Anropar spelarens EnterRoom-metod för att öka tur-räknaren
            player.EnterRoom();

            // Beräknar den sista siffran i spelarens tur-räknare
            char lastDigitChar = player.TurnCounter.ToString().Last();
            int lastDigit = Convert.ToInt32(lastDigitChar.ToString());

            // Om den sista siffran är 0 eller 5, så anropas en wandering monster
            if (lastDigit == 0 || lastDigit == 5)
            {
                // Kuslig medelande till spelaren
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You feel a chill in the air... A wandering monster approaches!");
                Console.ForegroundColor = ConsoleColor.White;

                // Anropar StartEncounter-metoden på wanderingMonster för att starta en emcounter
                wanderingMonster.StartEncounter();

                // Meddelande För att vissa att striden är över och återuppta rummet
                Console.WriteLine("You catch your breath after the battle...");
                resumeRoom.Invoke();
            }
        }
    }

}
