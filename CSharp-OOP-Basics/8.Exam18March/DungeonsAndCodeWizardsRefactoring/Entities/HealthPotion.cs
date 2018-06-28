using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizardsRefactoring.Static_Data;

namespace DungeonsAndCodeWizardsRefactoring.Entities
{
    class HealthPotion : Item
    {
        private const int Weight = 5;
        private const int HealthIncrease = 20;

        public HealthPotion() : base(Weight)
        {
            
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterMustBeAlive);
            }

            character.Health += HealthIncrease;
        }
    }
}
