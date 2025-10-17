using Bork_Dungeon_Crawler.Monsters;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Bork_Dungeon_Crawler
{
    //Användare = hjältar.
    //Quests = uppdrag/äventyr(med deadline och prioritet).
    //Appen = Quest Guild Terminal, där alla uppdrag och status rapporteras.
    //⚙️ Core Features
    //1. User Registration & Login (Hero Profile)

    //Skapa ny hjälteprofil med:
    //Username (hjältenamn)
    //Password (lösenord) – styrkekontroll (minst 6 tecken, 1 siffra, 1 stor bokstav, 1 specialtecken).
    //Email eller Phone för 2FA.

    //Vid inloggning:
    //Ange namn/lösenord.
    //Systemet skickar kod via SMS/Email(2FA) → måste anges korrekt för att komma in i guilden.
    internal class Program
    {

        static void Main(string[] args)
        {
            // Start the main menu
            //MainMenu menu = new MainMenu();
            //menu.mainMenu();




            // För att köra tester som hoppar över registrering och liknande
            Console.Write("Enter your hero's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your starting power level (e.g., 5): ");
            int powerLevel = Convert.ToInt32(Console.ReadLine());
            TestCharacter player = new TestCharacter(name, powerLevel);
            WanderingMonster wanderingMonster = new WanderingMonster();
            TurnManager turnManager = new TurnManager(player, wanderingMonster);
            Room_01_00 startRoom = new Room_01_00();
            startRoom.initialize(player, turnManager);
            startRoom.enterRoom();
        }
    }
}
