using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageName { get; }

        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        public Trader TraderHere { get; set; }

        public  Location(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public void AddMonster(int monsterID, int chanceofEncountering)
        {
            if(MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                //This monster has already loaded so overwrite the chanceOfEncountering with the new number
                MonstersHere.First(m => m.MonsterID == monsterID)
                            .ChanceOfEncountering = chanceofEncountering;
            }
            else
            {
                //This monster needs to loaded so add it
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceofEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            //Total percentages of all monsters at this location
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            //Selects a random number betweeen 1 and total chances of encounter
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            /*Loop through the monster list.
             * adding the monster's percentage chance of appearing to the runningTotal variable.
             * When the random number is lower than the runningTotal,
             * that is the monster to return*/
            int runningTotal = 0;

            foreach(MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if(randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            //If there was a problem, return the last monster in the list.
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}
