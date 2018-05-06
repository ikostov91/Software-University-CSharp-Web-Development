using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards;

namespace DungeonsAndCodeWizards
{
    public class Cleric : Character, IHealable
    {
        private const int StartingBaseHealth = 50;
        private const int StartingBaseArmor = 25;
        private const int StartingAbilityPoints = 40;

        public Cleric(string name, Faction faction) : base(name, StartingBaseHealth, StartingBaseArmor, StartingAbilityPoints, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Faction != character.Faction)
                {
                    throw new InvalidOperationException(ErrorMessages.CannotHealEnemy);
                }

                character.Health += this.AbilityPoints;
            }
            else
            {
                throw new ArgumentException(string.Format(ErrorMessages.CannotHeal, this.Name));
            }
        }
    }
}
