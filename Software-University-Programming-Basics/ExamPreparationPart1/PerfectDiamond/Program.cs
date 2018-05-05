using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDiamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int spaces = n - 1, stars = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(' ', spaces));
                Console.Write('*');

                for (int j = 0; j < stars; j++)
                {
                    Console.Write("-*");
                }
                Console.WriteLine();
                spaces--;
                stars++;
            }

            spaces = 1;
            stars = n - 2;

            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string(' ', spaces));
                Console.Write("*");

                for (int j = 0; j < stars; j++)
                {
                    Console.Write("-*");
                }
                Console.WriteLine();

                spaces++;
                stars--;
            }
        }
    }
}
