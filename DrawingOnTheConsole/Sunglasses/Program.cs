using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double middlePart = Math.Ceiling((double)n / 2);

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    Console.Write(new string('*', n * 2));
                    Console.Write(new string(' ', n));
                    Console.Write(new string('*', n * 2));
                }
                else if (i == middlePart)
                {
                    Console.Write('*');
                    Console.Write(new string('/',(n * 2) - 2));
                    Console.Write('*');
                    Console.Write(new string('|', n));
                    Console.Write('*');
                    Console.Write(new string('/', (n * 2) - 2));
                    Console.Write('*');
                }
                else
                {
                    Console.Write('*');
                    Console.Write(new string('/', (n * 2) - 2));
                    Console.Write('*');
                    Console.Write(new string(' ', n));
                    Console.Write('*');
                    Console.Write(new string('/', (n * 2) - 2));
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
