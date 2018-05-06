using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snakeText = Console.ReadLine();
            int[] shotParameters = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] matrix = new char[rows,cols];

            FillMatrix(matrix, snakeText);

            int impactRow = shotParameters[0];
            int impactColumn = shotParameters[1];
            int impactRadius = shotParameters[2];

            //PrintMatrix(matrix);

            PerformShot(matrix, impactRow, impactColumn, impactRadius);

            //PrintMatrix(matrix);

            DropElements(matrix);

            PrintMatrix(matrix);
        }

        private static void DropElements(char[,] matrix)
        {
            

            for (int i = matrix.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != ' ')
                    {
                        char currentCell = matrix[i,j];
                        //matrix[i, j] = ' ';

                        for (int k = i; k < matrix.GetLength(0) - 1; k++)
                        {
                            if (matrix[k + 1, j] == ' ')
                            {
                                matrix[k + 1, j] = currentCell;
                                matrix[k, j] = ' ';
                            }
                        }
                    }
                }
            }
        }

        private static void PerformShot(char[,] matrix, int impactRow, int impactColumn, int impactRadius)
        {
            matrix[impactRow, impactColumn] = ' ';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Pow(j - impactColumn,2) + Math.Pow(i - impactRow,2) < Math.Pow(impactRadius, 2))
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            int radius = impactRadius;

            if (impactRow + radius <= matrix.GetLength(0) - 1)
            {
                matrix[impactRow + radius, impactColumn] = ' ';
            }

            if (impactRow - radius >= 0)
            {
                matrix[impactRow - radius, impactColumn] = ' ';
            }

            if (impactColumn + radius <= matrix.GetLength(1) - 1)
            {
                matrix[impactRow, impactColumn + radius] = ' ';
            }

            if (impactColumn - radius >= 0)
            {
                matrix[impactRow, impactColumn - radius] = ' ';
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[,] matrix, string snakeText)
        {
            Queue<char> queue = new Queue<char>(snakeText.ToCharArray());
            string direction = "left";          

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                char currentChar;

                if (direction == "left")
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        currentChar = queue.Dequeue();
                        matrix[i, j] = currentChar;
                        queue.Enqueue(currentChar);
                    }
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        currentChar = queue.Dequeue();
                        matrix[i, j] = currentChar;
                        queue.Enqueue(currentChar);
                    }
                }

                if (direction == "left")
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }
            }
        }
    }
}
