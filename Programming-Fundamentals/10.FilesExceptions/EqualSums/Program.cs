using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;

            int currentNumber = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                currentNumber = sequence[i];

                for (int l = i - 1; l >= 0; l--)
                {
                    leftSum += sequence[l];
                }

                for (int r = i + 1; r < sequence.Length; r++)
                {
                    rightSum += sequence[r];
                }

                if (leftSum == rightSum)
                {
                    File.WriteAllText("output.txt", i.ToString());
                    return;
                }

                leftSum = 0;
                rightSum = 0;
            }

            File.WriteAllText("output.txt", "no");
        }
    }
}