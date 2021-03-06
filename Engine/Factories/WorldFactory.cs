﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "FarmFields.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 10);

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbour Farmer Frank.",
                "Farmhouse.png");
            newWorld.LocationAt(-1, -1).TraderHere = TraderFactory.GetTraderByName("Farmer Frank");

            newWorld.AddLocation(0, -1, "Home",
                "This is your home. Here you can heal by resting and save your game.",
                "Locations/Home.png");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Sarah, the trader.",
                "Trader.png");
            newWorld.LocationAt(-1, 0).TraderHere = TraderFactory.GetTraderByName("Sarah");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here. Throw a coin in for a wish... maybe...",
                "TownSquare.png");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "TownGate.png");

            newWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "HerbalistsHut.png");
            newWorld.LocationAt(0, 1).TraderHere = TraderFactory.GetTraderByName("Angela the Herbalist");

            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "HerbalistsGarden.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}
