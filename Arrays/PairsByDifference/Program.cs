using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            int pairsCount = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                for (int j = sequence.Length - 1; j > i; j--)
                {
                    if (Math.Abs(sequence[i] - sequence[j]) == number)
                    {
                        pairsCount += 1;
                    }
                }
            }

            Console.WriteLine(pairsCount);
        }
    }
}
