using System;
using System.Collections.Generic;
using Bork_Dungeon_Crawler_API.Dtos;

namespace Bork_Dungeon_Crawler_API.Models
{
    // Represents a room in the dungeon
    public class Room
    {
        // Primary key for database
        public int Id { get; set; }

        // Name or title of the room
        public string Title { get; set; } = "";

        // Short description of what the player sees
        public List<string> Description { get; set; } = new();

        // Available exits from this room (direction -> roomId)
        public Dictionary<string, int> Exits { get; set; } = new();

        // Optional scripted encounter for this room
        public Func<MonsterEventDto?>? Encounter { get; set; }
    }
}