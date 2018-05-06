using System;
using System.Linq;

namespace _2x2Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[rowsCols[0], rowsCols[1]];

            int countEqualSquares = 0;

            for (int i = 0; i < rowsCols[0]; i++)
            {
                char[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < rowsCols[1]; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            //PrintMatrix(matrix);

            for (int i = 0; i < rowsCols[0] - 1; i++)
            {
                for (int j = 0; j < rowsCols[1] - 1; j++)
                {
                    if (matrix[i,j] == matrix[i,j+1] && matrix[i + 1,j] == matrix[i + 1, j + 1] && matrix[i,j] == matrix[i + 1, j])
                    {
                        countEqualSquares += 1;
                    }
                }
            }

            Console.WriteLine(countEqualSquares);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
