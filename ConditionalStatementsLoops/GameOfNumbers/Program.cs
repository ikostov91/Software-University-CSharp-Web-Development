using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int last = int.Parse(Console.ReadLine());
            int magical = int.Parse(Console.ReadLine());

            int number1 = 0, number2 = 0, combinations = 0;

            for (int i = first; i <= last; i++)
            {
                for (int j = first; j <= last; j++)
                {
                    combinations++;

                    if ((i + j) == magical)
                    {
                        number1 = i;
                        number2 = j;
                    }
                }
            }

            if (number1 != 0)
            {
                Console.WriteLine("Number found! {0} + {1} = {2}", number1, number2, magical);
            }
            else
            {
                Console.WriteLine("{0} combinations - neither equals {1}", combinations, magical);
            }
        }
    }
}
