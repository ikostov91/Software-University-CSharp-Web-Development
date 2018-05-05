using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{2}", new string('.', n / 2), new string('#', n), new string('.', n / 2));

            for (int i = 1; i < n - 1; i++)
            {
                Console.WriteLine("{0}#{1}#{2}", new string('.', n / 2), new string('.', n - 2), new string('.', n / 2));
            }

            Console.WriteLine("{0}{1}{2}", new string('#', n / 2 + 1), new string('.', n - 2), new string('#', n / 2 + 1));

            int sideDots = 1, middleDots = 2 * n - 5;                       //middleDots = (n - 2) + (n - 3)

            for (int i = 1; i <= n - 1; i++)
            {
                if (i == n - 1)
                {
                    Console.WriteLine("{0}#{1}", new string('.', sideDots), new string('.', sideDots));
                }
                else
                {
                    Console.WriteLine("{0}#{1}#{2}", new string('.', sideDots), new string('.', middleDots), new string('.', sideDots));
                }           
                
                sideDots++;
                middleDots -= 2;
            }
        }
    }
}
