using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveDIfferentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if ((b - a) < 5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = a; i <= b; i++)
                {
                    for (int j = i + 1; j <= b; j++)
                    {
                        for (int k = j + 1; k <= b; k++)
                        {
                            for (int h = k + 1; h <= b; h++)
                            {
                                for (int l = h + 1; l <= b; l++)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4}", i, j, k, h, l);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
