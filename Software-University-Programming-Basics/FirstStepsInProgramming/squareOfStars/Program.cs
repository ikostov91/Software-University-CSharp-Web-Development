using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace squareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write('*');
                for (int k = 0; k < n - 2; k++)
                {
                    Console.Write(' ');
                }
                Console.Write('*');
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }
}
