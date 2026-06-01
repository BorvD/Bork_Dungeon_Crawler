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

                    // =========================
                    // ROOM-SPECIFIC ENCOUNTER
                    // =========================
                    // Detta rum har alltid en garanterad encounter
                    // när spelaren kommer in första gången
                    Encounter = () => new MonsterEventDto
                    {
                        MonsterName = "Imp",
                        PowerLevel = 2,
                        Description = "A vicious imp feeding on a corpse.",
                        Message =
                            "The imp hisses — low and eager.\n" +
                            "It drops the body and lunges toward you!"
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
                        "A damp, empty chamber.",
                        "A rusted chain swings slowly from the ceiling."
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
                        "Broken shelves and shattered jars line the walls.",
                        "Something small moves in the shadows."
                    },
                    Exits = new Dictionary<string, int>
                    {
                        { "east", 104 }
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
                        "You enter a narrow chamber cluttered with broken crates and cobwebs.",
                        "Nothing stirs but the dust."
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
                        "The room is small and bare, save for a single torch still burning low — someone has been here recently."
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
                        "You step into what was once a grand dining hall.",
                        "Long tables stretch across the room, now overturned and splintered.",
                        "Silver goblets lie scattered on the floor, their shine dulled beneath dust and dried blood."
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
                        "A narrow storage alcove.",
                        "Shattered jars leak a dark sticky residue across the floor."
                    },
                    Exits = new Dictionary<string, int>
                    {
                        { "east", 110 },
                        { "west", 108 }
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
                        "Rows of beds line the walls, torn and stained.",
                        "A dead body sits slumped against the wall."
                    },
                    Exits = new Dictionary<string, int>
                    {
                        { "west", 109 }
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
                        "Broken plates and moldy bread cover the shelves."
                    },
                    Exits = new Dictionary<string, int>
                    {
                        { "east", 108 },
                        { "west", 112 }
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
                        "The kitchen is ruined.",
                        "Smoke stains crawl up the stone walls."
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
                        "A heavy iron door stands before you.",
                        "Strange runes glow faintly along its surface."
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
                        "The final door stands silent.",
                        "Whatever lies beyond... is waiting."
                    },
                    Exits = new Dictionary<string, int>
                    {
                        { "north", 113 }
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