using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards;

namespace DungeonsAndCodeWizards
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name, 50, 25, 40, new Backpack(), faction)
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
                //throw new ArgumentException($"{this.Name} cannot heal!");
                throw new ArgumentException(string.Format(ErrorMessages.CannotHeal, this.Name));
            }
        }
    }
}
