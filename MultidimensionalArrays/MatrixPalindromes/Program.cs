using System;
using System.Linq;

namespace MatrixPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            string[,] matrix = new string[rowsColumns[0],rowsColumns[1]];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < rowsColumns[0]; i++)
            {
                for (int j = 0; j < rowsColumns[1]; j++)
                {
                    matrix[i, j] = alphabet[i].ToString() + alphabet[i + j] + alphabet[i];
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
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
