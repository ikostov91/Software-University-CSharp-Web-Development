using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int num = i;
                int sum = 0;


                while (num != 0)
                {
                    int remainder = num % 10;
                    sum += remainder;
                    num /= 10;
                }

                bool special = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine(i + " " + special);
            }
        }
    }
}
