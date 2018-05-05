using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastKNumbersSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            sequence[0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = i - k; j <= i - 1; j++)
                {
                    if (j < 0)
                    {
                        continue;
                    }
                    sequence[i] += sequence[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(sequence[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
