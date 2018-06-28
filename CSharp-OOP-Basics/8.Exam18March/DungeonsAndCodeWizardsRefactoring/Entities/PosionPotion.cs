using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizardsRefactoring.Static_Data;

namespace DungeonsAndCodeWizardsRefactoring.Entities
{
    class PosionPotion : Item
    {
        private const int Weight = 5;
        private const int HealthDecrease = 20;

        public PosionPotion() : base(Weight)
        {
                
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterMustBeAlive);    
            }

            character.Health -= HealthDecrease;
        }
    }
}
