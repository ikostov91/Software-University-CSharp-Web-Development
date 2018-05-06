using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0],size[1]];

            FillMatrix(matrix);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Nuke it from orbit")
                {
                    break;
                }

                int[] command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int row = command[0];
                int col = command[1];
                int radius = command[2];

                DestroyCells(matrix, row, col, radius);
                ModifyMatrix(matrix);

                //PrintMatrix(matrix);
            }

            PrintMatrix(matrix);
        }

        private static void ModifyMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j - 1] == 0)
                    {
                        ShiftCell(matrix, i,j);
                    }
                }
            }
        }

        private static void ShiftCell(int[,] matrix, int i, int j)
        {
            int index = j - 1;

            while (true)
            {
                if (matrix[i, index] == 0)
                {
                    matrix[i, index] = matrix[i,j];
                    matrix[i, j] = 0;
                }

                index -= 1;
                j -= 1;

                if (j == 0 || matrix[i, j - 1] != 0)
                {
                    return;
                }
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    counter += 1;
                    matrix[i, j] = counter;
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void DestroyCells(int[,] matrix, int row, int col, int radius)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                matrix[row, col] = 0;

                for (int i = row; i <= row + radius; i++)
                {
                    if (i > matrix.GetLength(0) - 1)
                    {
                        break;
                    }
                    matrix[i, col] = 0;
                }

                for (int i = row; i >= row - radius; i--)
                {
                    if (i < 0)
                    {
                        break;
                    }
                    matrix[i, col] = 0;
                }

                for (int i = col; i <= col + radius; i++)
                {
                    if (i > matrix.GetLength(1) - 1)
                    {
                        break;
                    }
                    matrix[row, i] = 0;
                }

                for (int i = col; i >= col - radius; i--)
                {
                    if (i < 0)
                    {
                        break;
                    }
                    matrix[row, i] = 0;
                }
            }
            else
            {
                if (row < 0 && row + radius >= 0 && col >= 0 && col < matrix.GetLength(1))
                {
                    for (int i = 0; i <= row + radius; i++)
                    {
                        matrix[i, col] = 0;
                    }
                }

                if (row >= matrix.GetLength(0) && row - radius < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                {
                    for (int i = matrix.GetLength(0) - 1; i >= row - radius; i--)
                    {
                        matrix[i, col] = 0;
                    }
                }

                if (col < 0 && col + radius >= 0 && row >= 0 && row < matrix.GetLength(0))
                {
                    for (int i = 0; i <= col + radius; i++)
                    {
                        matrix[row, i] = 0;
                    }
                }

                if (col >= matrix.GetLength(1) && col - radius < matrix.GetLength(1) && row >= 0 && row < matrix.GetLength(0))
                {
                    for (int i = matrix.GetLength(1) - 1; i >= col - radius; i--)
                    {
                        matrix[row, i] = 0;
                    }
                }
            }
        }
    }
}
