using System;
using System.Linq;

namespace RubikMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows,cols];

            matrix = FillMatrix(matrix);

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] currentCommand = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                int rowOrCol = int.Parse(currentCommand[0]);
                string direction = currentCommand[1];
                int howManyTimes = int.Parse(currentCommand[2]);

                matrix = ExecuteCommand(matrix, rowOrCol, direction, howManyTimes);

                //PrintMatrix(matrix);
            }

            //PrintMatrix(matrix);

            matrix = RearrangeMatrix(matrix);

            //PrintMatrix(matrix);
        }

        private static int[,] RearrangeMatrix(int[,] matrix)
        {
            int desiredValue = 0;
            bool isFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    desiredValue += 1;

                    if (matrix[i,j] != desiredValue)
                    {
                        for (int k = 0 + i; k < matrix.GetLength(0); k++)
                        {
                            for (int l = 0; l < matrix.GetLength(1); l++)
                            {
                                if (matrix[k, l] == desiredValue)
                                {
                                    int temp = matrix[i, j];
                                    matrix[i, j] = matrix[k, l];
                                    matrix[k, l] = temp;
                                    Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");

                                    isFound = true;
                                    break;
                                }
                            }

                            if (isFound)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No swap required");
                    }

                    isFound = false;
                }
            }

            return matrix;
        }

        private static int[,] ExecuteCommand(int[,] matrix, int rowOrCol, string direction, int howManyTimes)
        {
            int matrixRowCount = matrix.GetLength(0);
            int matrixColCount = matrix.GetLength(1);

            if (direction == "up" || direction == "down")
            {
                int[] col = new int[matrixRowCount];

                for (int i = 0; i < col.Length; i++)
                {
                    col[i] = matrix[i,rowOrCol];
                }

                col = RotateColumn(col, direction, howManyTimes);

                for (int i = 0; i < col.Length; i++)
                {
                    matrix[i, rowOrCol] = col[i];
                }
            }
            else
            {
                int[] row = new int[matrixColCount];

                for (int i = 0; i < row.Length; i++)
                {
                    row[i] = matrix[rowOrCol, i];
                }

                row = RotateRow(row, direction, howManyTimes);

                for (int i = 0; i < row.Length; i++)
                {
                    matrix[rowOrCol, i] = row[i];
                }
            }

            return matrix;
        }

        private static int[] RotateRow(int[] row, string direction, int howManyTimes)
        {
            for (int i = 0; i < howManyTimes % row.Length; i++)
            {
                if (direction == "right")
                {
                    int lastElement = row[row.Length - 1];

                    for (int j = row.Length - 1; j >= 1; j--)
                    {
                        row[j] = row[j - 1];
                    }

                    row[0] = lastElement;
                }
                else
                {
                    int lastElement = row[0];

                    for (int j = 0; j < row.Length - 1; j++)
                    {
                        row[j] = row[j + 1];
                    }

                    row[row.Length - 1] = lastElement;
                }
            }

            return row;
        }

        private static int[] RotateColumn(int[] col, string direction, int howManyTimes)
        {
            for (int i = 0; i < howManyTimes % col.Length; i++)
            {
                if (direction == "down")
                {
                    int lastElement = col[col.Length - 1];

                    for (int j = col.Length - 1; j >= 1; j--)
                    {
                        col[j] = col[j - 1];
                    }

                    col[0] = lastElement;
                }
                else
                {
                    int lastElement = col[0];

                    for (int j = 1; j < col.Length; j++)
                    {
                        col[j - 1] = col[j];
                    }

                    col[col.Length - 1] = lastElement;
                }
            }

            return col;
        }

        private static int[,] FillMatrix(int[,] matrix)
        {
            int counter = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter;
                    counter += 1;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " "); ;
                }
                Console.WriteLine();
            }
        }
    }
}
