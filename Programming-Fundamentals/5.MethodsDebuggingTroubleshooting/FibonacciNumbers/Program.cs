using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int fibonacciNumber = GetFibonacciNumber(n);
            Console.WriteLine(fibonacciNumber);
        }

        static int GetFibonacciNumber(int n)
        {
            int first = 0, second = 1, third = 0;

            if (n == 0)
            {
                return 1;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    third = first + second;
                    first = second;
                    second = third;
                }
                return third;
            }
        }
    }
}
