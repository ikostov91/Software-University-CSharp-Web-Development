using System;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int allRows = int.Parse(Console.ReadLine());

            for (int row = 1; row <= allRows; row++)
            {
                PrintRow(row, allRows);
            }

            for (int row = allRows - 1; row >= 1; row--)
            {
                PrintRow(row, allRows);
            }
        }

        private static void PrintRow(int row, int allRows)
        {
            Console.Write(new string(' ', allRows - row));
            Console.Write('*');

            for (int i = 1; i < row; i++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
        }
    }
}
