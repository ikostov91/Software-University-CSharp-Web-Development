using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    for (int k = n; k <= 1; k--)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int k = 0; k < i - 1; k++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }

            for (int i = 1; i < n; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int j = 1; j <= n - i - 1; j++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
