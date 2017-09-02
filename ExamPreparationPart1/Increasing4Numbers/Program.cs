using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Increasing4Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = a; i <= b; i++)
            {
                for (int k = i + 1; k <= b; k++)
                {
                    for (int j = k + 1; j <= b; j++)
                    {
                        for (int l = j + 1; l <= b; l++)
                        {
                            Console.WriteLine("{0} {1} {2} {3}", i, k, j, l);
                            count++;
                        }
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
