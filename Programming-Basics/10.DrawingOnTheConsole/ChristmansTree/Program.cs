using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmansTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var space = n - 1;

            Console.WriteLine(new string(' ', n) + " | " + new string(' ', n));
            for (int i = 1; i <= n; i++)
            {
                for (int k = 0; k < space; k++)
                {
                    Console.Write(' ');
                }
                for (int c = 1; c <= n - (space); c++)
                {
                    Console.Write('*');
                }
                Console.Write(" | ");
                for (int j = 1; j <= i; j++)
                {
                    Console.Write('*');
                }
                space--;
                Console.WriteLine();
            }
        }
    }
}
