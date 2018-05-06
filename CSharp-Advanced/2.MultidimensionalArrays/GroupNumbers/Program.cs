using System;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstRowLength = numbers.Where(x => Math.Abs(x) % 3 == 0).Count();
            int secondRowLength = numbers.Where(x => Math.Abs(x) % 3 == 1).Count();
            int thirdRowLength = numbers.Where(x => Math.Abs(x) % 3 == 2).Count();

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[firstRowLength];
            jaggedArray[1] = new int[secondRowLength];
            jaggedArray[2] = new int[thirdRowLength];

            int firstRowIndCounter = 0, secondRowIndCounter = 0, thirdRowIndCounter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Math.Abs(numbers[i]) % 3 == 0)
                {
                    jaggedArray[0][firstRowIndCounter] = numbers[i];
                    firstRowIndCounter += 1;
                }
                else if (Math.Abs(numbers[i]) % 3 == 1)
                {
                    jaggedArray[1][secondRowIndCounter] = numbers[i];
                    secondRowIndCounter += 1;
                }
                else if (Math.Abs(numbers[i]) % 3 == 2)
                {
                    jaggedArray[2][thirdRowIndCounter] = numbers[i];
                    thirdRowIndCounter += 1;
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        private static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int[] innerArray = jaggedArray[i];
                for (int j = 0; j < innerArray.Length; j++)
                {
                    if (j == innerArray.Length - 1)
                    {
                        Console.Write(innerArray[j]);
                    }
                    else
                    {
                        Console.Write(innerArray[j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
