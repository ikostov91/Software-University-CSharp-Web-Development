using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();

                FillMatrixRow(currentRow, i, matrix);
            }

            //PrintMatrix(matrix);

            int maxSquareSum = FindMaximumSquareSum(matrix);

            Console.WriteLine(maxSquareSum);

        }

        private static int FindMaximumSquareSum(int[,] matrix)
        {
            int currentSum = 0, maximumSum = 0;
            int firstSq = 0, secondSq = 0, thirdSq = 0, fourthSq = 0;
            int[,] maxElements = new int[2,2];

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    currentSum = matrix[i,j] + matrix[i,j + 1] + matrix[i + 1,j] + matrix[i+1,j+1];

                    if (currentSum > maximumSum)
                    {
                        maximumSum = currentSum;

                        firstSq = matrix[i,j]; 
                        secondSq = matrix[i, j + 1];
                        thirdSq = matrix[i + 1, j];
                        fourthSq = matrix[i + 1, j + 1];
                    }
                }
            }

            PrintSquare(firstSq, secondSq, thirdSq, fourthSq);

            return maximumSum;
        }

        private static void PrintSquare(int i, int i1, int i2, int i3)
        {
            Console.WriteLine($"{i} {i1}{Environment.NewLine}{i2} {i3}");
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
