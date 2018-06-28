using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DungeonsAndCodeWizardsRefactoring.Entities
{
    abstract class Item
    {
        private int weight;

        public Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public abstract void AffectCharacter(Character character);
    }
}
