using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write('*');
                for (int k = 0; k < n - 1; k++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
