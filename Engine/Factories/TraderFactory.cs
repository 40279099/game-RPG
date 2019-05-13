using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> _traders = new List<Trader>();

        static TraderFactory()
        {
            Trader sarah = new Trader("Sarah");
            sarah.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader farmerFrank = new Trader("Farmer Frank");
            farmerFrank.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader angelaTheHerbalist = new Trader("Angela the Herbalist");
            angelaTheHerbalist.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            AddTraderToList(sarah);
            AddTraderToList(farmerFrank);
            AddTraderToList(angelaTheHerbalist);
        }

        public static Trader GetTraderByName(string name)
        {
            return _traders.FirstOrDefault(t => t.Name == name);
        }

        private static void AddTraderToList(Trader trader)
        {
            if (_traders.Any(t => t.Name == trader.Name))
            {
                throw new ArgumentException($"There is already a trader name '{trader.Name}'.");
            }

            _traders.Add(trader);
        }
    }
}
