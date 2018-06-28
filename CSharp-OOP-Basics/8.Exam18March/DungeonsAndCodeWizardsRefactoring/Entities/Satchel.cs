using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizardsRefactoring.Entities
{
    class Satchel : Bag
    {
        private const int Capacity = 20;

        public Satchel() : base(Capacity)
        {
        }
    }
}
