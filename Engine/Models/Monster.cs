using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        
        public string ImageName { get; }
        public int MinimumDamage { get; }
        public int MaximumDamage { get; }

        public int RewardExperiencePoints { get; }
        
        public Monster(string name, string imageName, int maximumHitPoints, int hitPoints,
                       int minimumDamage, int maximumDamage, int rewardExperiencePoints, int rewardGold) :
                       base(name, maximumHitPoints, hitPoints,0, 0, 0, 0, rewardGold)
        {
            ImageName = $"/Engine/Models/Images/Monsters/{imageName}";
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
