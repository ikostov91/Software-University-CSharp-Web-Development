namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();

            dice.Sides = 6;
            dice.Row();
        }
    }
}
 