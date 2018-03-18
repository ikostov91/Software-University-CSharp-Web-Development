using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    class PoisonPotion : Item
    {
        public PoisonPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health -= 20;
            }
        }
    }
}
