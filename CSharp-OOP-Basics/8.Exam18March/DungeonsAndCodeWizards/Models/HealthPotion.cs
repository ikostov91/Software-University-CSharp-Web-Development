using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    class HealthPotion : Item
    {
        private const int Points = 20;

        public HealthPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += Points;
            }
        }
    }
}
