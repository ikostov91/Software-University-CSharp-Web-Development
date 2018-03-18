using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards;

namespace DungeonsAndCodeWizards
{
    public class Warrior : Character,  IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (character.Name == this.Name)
                {
                    throw new InvalidOperationException(ErrorMessages.CannotAttackSelf);
                }

                if (this.Faction == character.Faction)
                {
                    //throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
                    throw new ArgumentException(string.Format(ErrorMessages.FriendlyFire, this.Faction));
                }

                character.TakeDamage(this.AbilityPoints);
            }
            else
            {
                //throw new ArgumentException($"{this.Name} cannot attack!");
                throw new ArgumentException(string.Format(ErrorMessages.CannotAttack, this.Name));
            }
        }
    }
}
