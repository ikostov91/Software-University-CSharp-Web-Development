using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int first = 0, second = 1, third = 0;

            for (int i = 0; i < n; i++)
            {
                third = first + second;
                first = second;
                second = third;
            }

            Console.WriteLine(third);
        }
    }
}
