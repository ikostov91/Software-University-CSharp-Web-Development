using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace DungeonsAndCodeWizards
{
    class HealthPotion : Item
    {
        public HealthPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += 20;
            }
        }
    }
}
