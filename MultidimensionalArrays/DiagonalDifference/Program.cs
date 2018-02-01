using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            //PrintMatrix(matrix);

            int primaryDiagonalSum = 0, secondaryDiagonalSum = 0;
            int counter1 = 0, counter2 = 0;

            for (int i = 0; i < size; i++)
            {
                primaryDiagonalSum += matrix[counter1, counter2];
                counter1 += 1;
                counter2 += 1;
            }

            counter1 = 0;
            counter2 = size - 1;

            for (int i = 0; i < size; i++)
            {
                secondaryDiagonalSum += matrix[counter1, counter2];
                counter1 += 1;
                counter2 -= 1;
            }

            int absDiff = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(absDiff);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
