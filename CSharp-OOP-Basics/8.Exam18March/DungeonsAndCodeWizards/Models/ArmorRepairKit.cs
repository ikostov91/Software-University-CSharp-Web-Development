using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    class ArmorRepairKit : Item
    {
        public ArmorRepairKit() : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Armor += character.BaseArmor;
            }
        }
    }
}
