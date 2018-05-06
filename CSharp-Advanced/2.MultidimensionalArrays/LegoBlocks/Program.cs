using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArrayOne = new int[rows][];
            int[][] jaggedArrayTwo = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] inputLine = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                jaggedArrayOne[i] = new int[inputLine.Length];

                for (int j = 0; j < inputLine.Length; j++)
                {
                    jaggedArrayOne[i][j] = inputLine[j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                int[] inputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                jaggedArrayTwo[i] = new int[inputLine.Length];

                for (int j = 0; j < inputLine.Length; j++)
                {
                    jaggedArrayTwo[i][j] = inputLine[j];
                }
            }

            bool doArraysFit = CheckIfArraysFit(jaggedArrayOne, jaggedArrayTwo);

            if (doArraysFit)
            {
                int matrixLength = jaggedArrayOne[0].Length + jaggedArrayTwo[0].Length;

                int[,] matrix = new int[rows,matrixLength];

                matrix = FillMatrix(matrix, jaggedArrayOne, jaggedArrayTwo);

                PrintMatrix(matrix);
            }
            else
            {
                int cellsFirstArray = CountCells(jaggedArrayOne);
                int cellsSecondArray = CountCells(jaggedArrayTwo);

                int allCells = cellsFirstArray + cellsSecondArray;

                Console.WriteLine($"The total number of cells is: {allCells}");
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {  
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Console.Write($"{matrix[i,j]}");
                    }
                    else
                    {
                        Console.Write($"{matrix[i,j]}, ");
                    }
                }
                Console.WriteLine("]");
            }
        }

        private static int[,] FillMatrix(int[,] matrix, int[][] jaggedArrayOne, int[][] jaggedArrayTwo)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < jaggedArrayOne[i].Length; j++)
                {
                    matrix[i, j] = jaggedArrayOne[i][j];
                }

                int index = matrix.GetLength(1) - 1;

                for (int j = 0; j < jaggedArrayTwo[i].Length; j++)
                {
                    matrix[i, index] = jaggedArrayTwo[i][j];
                    index -= 1;
                }
            }

            return matrix;
        }

        private static int CountCells(int[][] jaggedArray)
        {
            int counter = 0;

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    counter += 1;
                }
            }

            return counter;
        }

        private static bool CheckIfArraysFit(int[][] jaggedArrayOne, int[][] jaggedArrayTwo)
        {
            int firstRowLength = jaggedArrayOne[0].Length + jaggedArrayTwo[0].Length;

            for (int i = 1; i < jaggedArrayOne.Length; i++)
            {
                if (jaggedArrayOne[i].Length + jaggedArrayTwo[i].Length != firstRowLength)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
