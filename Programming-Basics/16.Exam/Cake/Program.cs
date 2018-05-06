using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int totalCake = cakeWidth * cakeLength, pieces = 0;

            string stopCommand = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    Console.WriteLine("{0} pieces are left.", totalCake);
                    break;
                }
                else
                {
                    //pieces = Convert.ToInt32(input);
                    pieces = int.Parse(input);

                    totalCake -= pieces;
                    if (totalCake < 0)
                    {
                        Console.WriteLine("No more cake left! You need {0} pieces more.", Math.Abs(totalCake));
                        break;
                    }
                }
            }
        }
    }
}
