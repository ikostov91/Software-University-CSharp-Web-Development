using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards;

namespace DungeonsAndCodeWizards
{
    public class Warrior : Character,  IAttackable
    {
        private const int StartingBaseHealth = 100;
        private const int StartingBaseArmor = 50;
        private const int StartingAbilityPoints = 40;

        public Warrior(string name, Faction faction) : base(name, StartingBaseHealth, StartingBaseArmor, StartingAbilityPoints, new Satchel(), faction)
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
                    throw new ArgumentException(string.Format(ErrorMessages.FriendlyFire, this.Faction));
                }

                character.TakeDamage(this.AbilityPoints);
            }
            else
            {
                throw new ArgumentException(string.Format(ErrorMessages.CannotAttack, this.Name));
            }
        }
    }
}
