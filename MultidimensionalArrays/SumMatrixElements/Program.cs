using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();

                FillMatrixRow(currentRow, i, matrix);
            }

            //PrintMatrix(matrix);

            int sumOfAllElements = SumMatrixElements(matrix);

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sumOfAllElements);
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
                        Console.Write(matrix[i,j] + ", ");
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

        private static int SumMatrixElements(int[,] matrix)
        {
            int sum = 0;

            foreach (var number in matrix)
            {
                sum += number;
            }

            return sum;
        }
    }
}
