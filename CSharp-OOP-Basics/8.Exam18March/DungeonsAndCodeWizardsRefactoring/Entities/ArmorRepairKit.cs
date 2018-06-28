using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizardsRefactoring.Static_Data;

namespace DungeonsAndCodeWizardsRefactoring.Entities
{
    class ArmorRepairKit : Item
    {
        private const int Weight = 10;

        public ArmorRepairKit() : base(Weight)
        {
                
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterMustBeAlive);
            }

            character.Armor = character.BaseArmor;
        }
    }
}
