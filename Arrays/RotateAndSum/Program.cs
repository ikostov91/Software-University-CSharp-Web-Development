using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sum = new int[numbers.Length];

            int k = int.Parse(Console.ReadLine());

            int[] rotateAndSum = RotateSumArrays(numbers, sum, k);

            PrintArray(rotateAndSum);
        }

        private static void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }

        private static int[] FillArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            return numbers;
        }

        private static int[] RotateSumArrays(int[] numbers, int[] sum, int k)
        {
            for (int j = 0; j < k; j++)
            {
                int last = numbers[numbers.Length - 1];

                for (int i = numbers.Length - 2; i >= 0; i--)
                {
                    numbers[i + 1] = numbers[i];
                }
                numbers[0] = last;

                for (int i = 0; i < numbers.Length; i++)
                {
                    sum[i] += numbers[i];
                }
            }
            
            return sum;
        }
    }
}
