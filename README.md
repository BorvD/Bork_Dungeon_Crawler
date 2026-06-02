Bork Dungeon Crawler
A turn based dungeon crawler built in C# using ASP.NET, Blazor, and clean architecture principles.

Players explore a dungeon encounter by encounter. Now it is mostly just rooms you walk between and encounter monsters. Both random and fixed.
It is inspired by the old games like Zoork and other text based games.
The game has been a growing project where i test the things i have learned in school and the implemented into the game struckture.
That is why there is two diffren projekts that has nothing to do with each other. It started with the console version and then i took my code and moved it and made an API version.

Features:
  - Room bades dungeon exploration
  - Branching pathes you can take and walk between rooms
  - Turn based progression that goes up when you walk between rooms
  - Random Encounters 
  - Room specific scripted encounters
  - Rest API Backend
  - A standard console driven older verions that is started from its own Program.cs


  Structure:
  
  Bork_Dungeon_Crawler (Older console version)
  
  The original console version of the game.
  Contains the first implements of:
  - Character system (Register and Login in a very simple version)
  - Rooms
  - Encounters
  - turn manegment
  - Dungeon exploration.

  I wanted to have the files stil there as a refrense, And how the game started. If i want i might build it here also.


Bork_Dungeon_Crawler_API

ASP.NET core wweb API. Responsible for:

- Dungeon navigation (Now you just walk the four Cardinal directions)
- Room managment
- Encounter generation
- Turn Tracking
- Game state handling.

Main Endpoints:

http Get /api/dungeon/current
Returns the players cuttent room.

http Post /api/dungeon/move
Moves the player in a chosen direction.




Bork_Dungeon_Crawler_UI

Blazor Server Frontend. Responsible for:
- Displaying room descriptions
- Showing avalible exits
- Displayes encounters
- Sending player actions to the API


How it works:
Every room contains:
- Unique room ID
- Title
- Description
- Available exits
- Encounters

Example:
    Room 100
        | 
      South
      North
        | 
    Room 101
    /   |   \
West  South  East


Encounter Systems:
Right now it has two diffren types of encounters

Room encounter:
Some rooms has events where the char meats enemies. I will later have items that can be found in rooms.
They are coded to the room

Turn Encounters:
Right now the API tracks how many turns the game has had. And in every 5 turns the char meets a random monster before enetring the room:


Tech:
- C#
- Asp.NET core web API
- Blazor server
- Dependency Injection
- Rest API
- GitHub


Running the projeckt:
Open BorkDungeonCrawler.sln
Configure multiple solution:
  - Bork_Dungeon_Crawler_API
  - Bork_Dungeon_Crawler_UI
  Start the solution.
  It will start and launch a page where the game starts

  Running the old projekt:
  Run solution Bork_Dungeon_Crawler


  This whole project is me implementing stuff i have learnt from school. It showes what the course has been about so far. A way to learn by doing.


  Future plans:
  - Make a good frontend. Now it is the most basic and barley work.
  - make a combat system for the game. I have some ideas
  - Inventory system and items in encounters.
  - Save and load functions
  - Then just grow the game both in scope, but with new things i learn to do.
