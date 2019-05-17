using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Actions
{
    public class AttackWithWeapon
    {
        private readonly GameItem _weapon;
        private readonly int _minimumDamage;
        private readonly int _maximumDamage;

        public event EventHandler<string> OnActionPerformed;

        public AttackWithWeapon(GameItem weapon, int minimumDamage, int maximumDamage)
        {
            if(weapon.Category != GameItem.ItemCategory.Weapon)
            {
                throw new ArgumentException($"{weapon.Name} is not a weapon.");
            }

            if(_minimumDamage < 0)
            {
                throw new ArgumentException("minimumDamage must be greater than 0.");
            }

            if(_maximumDamage < _minimumDamage)
            {
                throw new ArgumentException("maximumDamage must be >= minimumDamage");
            }

            _weapon = weapon;
            _minimumDamage = minimumDamage;
            _maximumDamage = maximumDamage;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            int damage = RandomNumberGenerator.NumberBetween(_minimumDamage, _maximumDamage);

            if(damage == 0)
            {
                ReportResult($"Haha! You missed the {target.Name} by a mile!");
            }
            else
            {
                ReportResult($"You hit the {target.Name} for {damage} points.");
                target.TakeDamage(damage);
            }
        }

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
