using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1, sum = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}", number);
                sum += number;
                number += 2;
            }

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
