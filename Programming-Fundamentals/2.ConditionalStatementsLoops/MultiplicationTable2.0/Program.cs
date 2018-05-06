using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier > 10)
            {
                Console.WriteLine("{0} X {1} = {2}", number, multiplier, number * multiplier);
            }
            else
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine("{0} X {1} = {2}", number, i, number * i);
                }
            }
        }
    }
}
