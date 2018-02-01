using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();

                FillMatrixRow(currentRow, i, matrix);
            }

            //PrintMatrix(matrix);

            FindMaximumSquareSum(matrix);
        }

        private static void FindMaximumSquareSum(int[,] matrix)
        {
            int currentSum = 0, maximumSum = 0;
            int firstSq = 0, secondSq = 0, thirdSq = 0, fourthSq = 0, fifthSq = 0, sixthSq = 0, seventSq = 0, eightSq = 0, ninthSq = 0;

            int maxSquareSum = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i,j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1,j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (currentSum > maximumSum)
                    {
                        maximumSum = currentSum;

                        firstSq = matrix[i, j];
                        secondSq = matrix[i, j + 1];
                        thirdSq = matrix[i, j + 2];
                        fourthSq = matrix[i + 1, j];
                        fifthSq = matrix[i + 1, j + 1];
                        sixthSq = matrix[i + 1, j + 2];
                        seventSq = matrix[i + 2, j];
                        eightSq = matrix[i + 2, j + 1];
                        ninthSq = matrix[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maximumSum}");

            PrintSquare(firstSq, secondSq, thirdSq, fourthSq, fifthSq, sixthSq, seventSq, eightSq, ninthSq);
        }

        private static void PrintSquare(int i, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8)
        {
            Console.WriteLine($"{i} {i1} {i2}{Environment.NewLine}{i3} {i4} {i5}{Environment.NewLine}{i6} {i7} {i8}");
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + ", ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrixRow(int[] currentRow, int i, int[,] matrix)
        {
            for (int j = 0; j < currentRow.Length; j++)
            {
                matrix[i, j] = currentRow[j];
            }
        }
    }
}
