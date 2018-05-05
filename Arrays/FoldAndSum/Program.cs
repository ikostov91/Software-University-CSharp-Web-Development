using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = numbers.Length / 4;

            int[] firstRow = GetFirstRow(numbers, k);
            int[] secondRow = GetSecondRow(numbers, k);
            int[] arraysSum = SumArray(firstRow, secondRow);

            PrintArray(arraysSum);
        }

        private static void PrintArray(int[] arraysSum)
        {
            for (int i = 0; i < arraysSum.Length; i++)
            {
                Console.Write(arraysSum[i] + " ");
            }
            Console.WriteLine();
        }

        private static int[] GetFirstRow(int[] numbers, int k)
        {
            int[] firstRow = new int[numbers.Length / 2];
            int count = 0;

            for (int i = 0; i < firstRow.Length / 2; i++)
            {
                firstRow[i] = numbers[numbers.Length / 4 - 1 - i];
            }

            for (int i = firstRow.Length / 2; i <= firstRow.Length - 1; i++)
            {
                firstRow[i] = numbers[numbers.Length - 1 - count];
                count += 1;
            }

            return firstRow;
        }

        private static int[] GetSecondRow(int[] numbers, int k)
        {
            int[] secondRow = new int[numbers.Length / 2];
            int length = 0;

            for (int i = k; i <= 3 * k - 1; i++)
            {
                secondRow[length] = numbers[i];
                length += 1;
            }

            return secondRow;
        }

        private static int[] SumArray(int[] firstRow, int[] secondRow)
        {
            int[] sum = new int[firstRow.Length];

            for (int i = 0; i < firstRow.Length; i++)
            {
                sum[i] = firstRow[i] + secondRow[i];
            }

            return sum;
        }
    }
}
