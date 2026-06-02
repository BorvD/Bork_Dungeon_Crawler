using System.Collections.Generic;
using System.Linq;
using Bork_Dungeon_Crawler_API.Dtos;
using Bork_Dungeon_Crawler_API.Models;

namespace Bork_Dungeon_Crawler_API.Services
{

    /// Detta är spelets kärnlogik för dungeon-systemet.
    ///
    /// Ansvar:
    /// - Håller koll på spelarens position i dungeon
    /// - Hanterar movement mellan rooms
    /// - Räknar turns per spelare
    /// - Triggar encounters (room-baserade och turn-baserade)
    ///
    /// Viktigt:
    /// ALL room-text är 1:1 migrerad från Console-versionen.
    /// Den får inte ändras eftersom den måste matcha spelet exakt.
    /// </summary>
    public class DungeonRoomService
    {

        // PLAYER STATE

        // Vilket rum varje spelare befinner sig i
        private readonly Dictionary<int, int> _characterRooms = new();

        // Turn counter per spelare (används för global encounter-logik)
        private readonly Dictionary<int, int> _characterTurns = new();

        // Spårar vilka rum som redan har haft encounter för en spelare
        // Detta förhindrar att samma encounter triggas flera gånger
        private readonly Dictionary<int, HashSet<int>> _clearedEncounters = new();

        private readonly MonsterService _monsterService;


        public DungeonRoomService(MonsterService monsterService)
        {
            _monsterService = monsterService;
        }



        // ROOM DATABASE (STATIC WORLD MAP)
        //
        // Detta är hela dungeon-kartan.
        // Varje rum innehåller:
        // - Id
        // - Title
        // - Description (exakt console-text)
        // - Exits (kopplingar till andra rum)
        // - Optional Encounter (för specifika rum som 103)
        //
        private readonly Dictionary<int, Room> _rooms = new()
{
    {
        100, new Room
        {
            Id = 100,
            Title = "Dungeon Entrance",
            Description = new List<string>
            {
                "The stone steps groan beneath your boots.",
                "The air is cold and heavy.",
                "The dungeon has accepted you."
            },
            Exits = new Dictionary<string, int>
            {
                { "south", 101 }
            }
        }
    },

    {
        101, new Room
        {
            Id = 101,
            Title = "Broken Hall",
            Description = new List<string>
            {
                "You step through the doorway and into a long, shadow-drenched hall.",
                "Broken furniture litters the floor — tables split in half, chairs overturned, scorch marks staining the stone.",
                "The air smells faintly of smoke and blood.",
                "",
                "Something terrible happened here... and not long ago.",
                "",
                "Deep gouges run along the walls, as if some great beast had torn through the room in fury.",
                "A shattered sword lies beside a dented helm, both slick with fresh rust.",
                "",
                "You kneel and touch the ground — it’s still warm.",
                "Whatever fought here, whatever died here... it might still be close."
            },
            Exits = new Dictionary<string, int>
            {
                { "north", 100 },
                { "south", 106 },
                { "east", 104 },
                { "west", 102 }
            }
        }
    },

    {
        102, new Room
        {
            Id = 102,
            Title = "Stone Alcove",
            Description = new List<string>
            {
                "A low alcove with faded markings carved into the stone.",
                "The air is damp and still."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 101 },
                { "west", 103 }
            }
        }
    },

    {
        103, new Room
        {
            Id = 103,
            Title = "Blood Chamber",
            Description = new List<string>
            {
                "The corridor opens into a cramped chamber.",
                "A foul stench hangs heavy in the air.",
                "",
                "There — crouched beside a torn corpse — an imp giggles...",
                "Its claws are slick with blood, its eyes glowing faintly in the dark.",
                "",
                "When it sees you, the grin widens."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 102 }
            },
            Encounter = () => new MonsterEventDto
            {
                MonsterName = "Imp",
                PowerLevel = 2,
                Description = "A vicious imp feeding on a corpse.",
                Message =
                    "The imp hisses — low and eager.\nIt lunges toward you!"
            }
        }
    },

    {
        104, new Room
        {
            Id = 104,
            Title = "Small Chamber",
            Description = new List<string>
            {
                "A small room opens before you — damp, silent, and empty,",
                "save for a single rusted chain swaying gently from the ceiling."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 101 },
                { "west", 105 }
            }
        }
    },

    {
        105, new Room
        {
            Id = 105,
            Title = "Storage Room",
            Description = new List<string>
            {
                "You open a narrow door leading into a cramped side room.",
                "The air is warm and smells faintly of sulfur and burnt wood.",
                "",
                "A small imp hides among broken shelves, trembling.",
                "It looks more scared than dangerous."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 104 }
            },
            Encounter = () => new MonsterEventDto
            {
                MonsterName = "Small Imp",
                PowerLevel = 1,
                Description = "A frightened imp hiding in storage.",
                Message =
                    "A small imp jumps out from behind a shelf."
            }
        }
    },

    {
        106, new Room
        {
            Id = 106,
            Title = "Corridor",
            Description = new List<string>
            {
                "A narrow corridor filled with broken crates and dust.",
                "Nothing moves here."
            },
            Exits = new Dictionary<string, int>
            {
                { "north", 101 },
                { "south", 107 }
            }
        }
    },

    {
        107, new Room
        {
            Id = 107,
            Title = "Torch Room",
            Description = new List<string>
            {
                "A dim room with a single torch still burning.",
                "Someone was here recently."
            },
            Exits = new Dictionary<string, int>
            {
                { "north", 106 },
                { "south", 108 }
            }
        }
    },

    {
        108, new Room
        {
            Id = 108,
            Title = "Dining Hall",
            Description = new List<string>
            {
                "A ruined dining hall.",
                "Tables are overturned and covered in dust and blood.",
                "A faint sound of metal echoes somewhere in the room."
            },
            Exits = new Dictionary<string, int>
            {
                { "north", 107 },
                { "east", 109 },
                { "west", 111 },
                { "south", 113 }
            }
        }
    },

    {
        109, new Room
        {
            Id = 109,
            Title = "Storage",
            Description = new List<string>
            {
                "A narrow storage alcove filled with shattered jars."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 108 },
                { "west", 110 }
            }
        }
    },

    {
        110, new Room
        {
            Id = 110,
            Title = "Sleeping Quarters",
            Description = new List<string>
            {
                "Beds line the walls.",
                "A corpse lies slumped against one wall.",
                "",
                "It moves..."
            },
            Exits = new Dictionary<string, int>
            {
                { "west", 109 }
            },
            Encounter = () => new MonsterEventDto
            {
                MonsterName = "Undead Warrior",
                PowerLevel = 5,
                Description = "A reanimated soldier.",
                Message = "The corpse rises slowly..."
            }
        }
    },

    {
        111, new Room
        {
            Id = 111,
            Title = "Pantry",
            Description = new List<string>
            {
                "A cramped pantry filled with rotten food."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 112 },
                { "west", 108 }
            }
        }
    },

    {
        112, new Room
        {
            Id = 112,
            Title = "Kitchen",
            Description = new List<string>
            {
                "A ruined kitchen covered in soot and ash."
            },
            Exits = new Dictionary<string, int>
            {
                { "east", 111 }
            }
        }
    },

    {
        113, new Room
        {
            Id = 113,
            Title = "Iron Door Hall",
            Description = new List<string>
            {
                "A long hall ending in a massive iron door.",
                "The door is sealed tight."
            },
            Exits = new Dictionary<string, int>
            {
                { "north", 108 },
                { "south", 114 }
            }
        }
    },

    {
        114, new Room
        {
            Id = 114,
            Title = "Final Door",
            Description = new List<string>
            {
                "A heavy iron door stands sealed.",
                "Four imps guard it silently.",
                "",
                "The door cannot be opened yet."
            },
            Exits = new Dictionary<string, int>
            {
                { "north", 113 }
            },
            Encounter = () => new MonsterEventDto
            {
                MonsterName = "Imp Pack",
                PowerLevel = 7,
                Description = "Four imps guarding the sealed door.",
                Message = "The imps block your path."
            }
        }
    }
};


        // GET CURRENT ROOM
        public Room GetCurrentRoom(int characterId)
        {
            if (!_characterRooms.ContainsKey(characterId))
                _characterRooms[characterId] = 100;

            return _rooms[_characterRooms[characterId]];
        }


        // MOVE PLAYER
        public RoomResponse Move(int characterId, string direction)
        {
            var currentRoom = GetCurrentRoom(characterId);

            direction = direction.ToLower();

            if (!_characterTurns.ContainsKey(characterId))
                _characterTurns[characterId] = 0;

            // Om ogiltig riktning -> stanna kvar men räkna turn
            if (!currentRoom.Exits.ContainsKey(direction))
            {
                IncrementTurn(characterId);
                return CreateResponse(currentRoom, null);
            }

            // Move player into next room
            int nextRoom = currentRoom.Exits[direction];
            _characterRooms[characterId] = nextRoom;

            IncrementTurn(characterId);

            var room = _rooms[nextRoom];

            // Encounter som ska skickas tillbaka till frontend.
            // Null betyder att inget encounter inträffade.
            MonsterEventDto? encounter = null;

            // 1. ROOM ENCOUNTER (högsta prio)
            if (room.Encounter != null &&
                !HasClearedEncounter(characterId, room.Id))
            {
                encounter = room.Encounter();

                // Markera encountert som avklarat så det
                // inte triggas nästa gång spelaren går in.
                MarkEncounterCleared(characterId, room.Id);

                return CreateResponse(room, encounter);
            }

            // 2. TURN ENCOUNTER (var 5:e turn)
            if (_characterTurns[characterId] % 5 == 0)
            {
                encounter = _monsterService.GenerateEncounter();
            }

            return CreateResponse(room, encounter);
        }


        // TURN SYSTEM
        private void IncrementTurn(int characterId)
        {
            _characterTurns[characterId]++;
        }


        // ENCOUNTER SYSTEM
        // OBS: denna är inte längre del av spel-loopen (legacy/debug)
        private void TriggerEncounter(int characterId)
        {
            var encounter = _monsterService.GenerateEncounter();

            System.Console.WriteLine("=== ENCOUNTER ===");
            System.Console.WriteLine($"Monster: {encounter.MonsterName}");
            System.Console.WriteLine($"Power: {encounter.PowerLevel}");
            System.Console.WriteLine(encounter.Message);
            System.Console.WriteLine("=================");
        }


        // HELPERS
        private RoomResponse CreateResponse(Room room, MonsterEventDto? encounter)
        {
            return new RoomResponse
            {
                RoomId = room.Id,
                Title = room.Title,
                Description = room.Description,
                Options = room.Exits.Keys.ToList(),
                Encounter = encounter
            };
        }

        private bool HasClearedEncounter(int characterId, int roomId)
        {
            return _clearedEncounters.ContainsKey(characterId) &&
                   _clearedEncounters[characterId].Contains(roomId);
        }

        private void MarkEncounterCleared(int characterId, int roomId)
        {
            if (!_clearedEncounters.ContainsKey(characterId))
                _clearedEncounters[characterId] = new HashSet<int>();

            _clearedEncounters[characterId].Add(roomId);
        }
    }
}