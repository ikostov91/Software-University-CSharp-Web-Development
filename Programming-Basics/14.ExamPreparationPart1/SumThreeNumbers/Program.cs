using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            if (first + second == third)
            {
                if (first <= second)
                {
                    Console.WriteLine("{0} + {1} = {2}", first, second, third);
                }
                else
                {
                    Console.WriteLine("{0} + {1} = {2}", second, first, third);
                }
            }
            else if (second + third == first)
            {
                if (second <= third)
                {
                    Console.WriteLine("{0} + {1} = {2}", second, third, first);
                }
                else
                {
                    Console.WriteLine("{0} + {1} = {2}", third, second, first);
                }
            }
            else if (first + third == second)
            {
                if (first <= third)
                {
                    Console.WriteLine("{0} + {1} = {2}", first, third, second);
                }
                else
                {
                    Console.WriteLine("{0} + {1} = {2}", third, first, second);
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
