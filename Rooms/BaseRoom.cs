using Bork_Dungeon_Crawler.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bork_Dungeon_Crawler.Rooms
{
    // Abstrakt bas rum där alla andra rum ärver ifrån
    public abstract class BaseRoom
    {
        // Referenser till spelarkaraktären och turhanteraren
        protected TestCharacter player;
        protected TurnManager turnManager;

        //Metod för att starta rummet med spelare och turhanterare
        public void Initialize(TestCharacter player, TurnManager turnManager)
        {
            // Referencr till spelare och turhanterare
            this.player = player;
            this.turnManager = turnManager;
        }

        // Abstrakt metod som måste implementeras i alla ärvda rumsklasser
        public abstract void EnterRoom();
    }
}
