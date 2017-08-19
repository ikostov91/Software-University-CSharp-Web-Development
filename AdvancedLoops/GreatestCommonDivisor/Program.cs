using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int i = 1, GCD = 0;

            while (i <= number1 || i <= number2)
            {
                if (number1 % i == 0 && number2 % i == 0)
                {
                    GCD = i;
                }
                i++;
            }

            Console.WriteLine("GCD = {0}", GCD);
        }
    }
}
