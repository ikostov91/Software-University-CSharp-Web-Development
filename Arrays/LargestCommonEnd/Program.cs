using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(' ').ToArray();
            string[] second = Console.ReadLine().Split(' ').ToArray();
            GetLargestCommondEnd(first, second);
        }

        private static void GetLargestCommondEnd(string[] first, string[] second)
        {
            int leftCommonEnd = 0, rightCommonEnd = 0;

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (first[i] == second[i])
                {
                    leftCommonEnd += 1;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                int rightCount = i;

                if (first[first.Length - rightCount - 1] == second[second.Length - rightCount - 1])
                {
                    rightCommonEnd += 1;
                }
                else
                {
                    break;
                }
            }

            if (leftCommonEnd > rightCommonEnd)
            {
                Console.WriteLine(leftCommonEnd);
            }
            else if (rightCommonEnd > leftCommonEnd)
            {
                Console.WriteLine(rightCommonEnd);
            }
            else
            {
                Console.WriteLine(leftCommonEnd);
            }
        }
    }
}
