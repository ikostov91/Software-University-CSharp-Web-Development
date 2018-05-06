using System;

namespace Dice
{
    public class Dice
    {
        // No Modifier - Default is private
        int sides;
        int type;

        public int Sides
        {
            get { return this.sides;  }
            set { this.sides = value; }
        }

        public void Row()
        {
            Random rnd = new Random();
            int rndSide = rnd.Next(1, sides + 1);
            Console.WriteLine(rndSide);
        }
    }
}
