using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[,] board = new char[boardSize,boardSize];

            FillBoard(board, boardSize);
            int knightsRemoved = 0;

            while (true)
            {
                int[] position = new int[2];
                position = FindKnightWithMostAttackingPositions(board);

                if (position == null)
                {
                    break;
                }

                board[position[0], position[1]] = 'O';
                knightsRemoved++;

            }

            Console.WriteLine(knightsRemoved);
            //PrintBoard(board);
        }

        private static int[] FindKnightWithMostAttackingPositions(char[,] board)
        {
            int maxPositions = 0;

            List<int[]> attackingKnights = new List<int[]>();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (board[row, column] == 'K')
                    {
                        int attackingPositions = KnightCanAttack(board, row, column);

                        if (attackingPositions > maxPositions)
                        {
                            maxPositions = attackingPositions;
                            attackingKnights.Add(new int[] { row, column });
                        }  
                    }
                }
            }

            int[] knightWithMostPositions = attackingKnights[attackingKnights.Count - 1];

            return knightWithMostPositions;
        }

        private static int KnightCanAttack(char[,] board, int row, int column)
        {
            int positionsCounter = 0;

            int[][] attackingPositions = GetAttackingPositions(row, column);

            for (int position = 0; position < attackingPositions.GetLength(0); position++)
            {
                if (attackingPositions[position][0] < 0 || attackingPositions[position][0] >= board.GetLength(0) || attackingPositions[position][1] < 0 || attackingPositions[position][1] >= board.GetLength(1))
                {
                    continue;
                }
                else
                {
                    if (board[attackingPositions[position][0], attackingPositions[position][1]] == 'K')
                    {
                        positionsCounter++;
                    }
                }
            }

            return positionsCounter;
        }

        private static int[][] GetAttackingPositions(int row, int column)
        {
            int[][] jaggedArray = new int[8][];
            jaggedArray[0] = new int[] { row - 2, column + 1 };
            jaggedArray[1] = new int[] { row - 2, column - 1 };
            jaggedArray[2] = new int[] { row - 1, column + 2 };
            jaggedArray[3] = new int[] { row - 1, column - 2 };
            jaggedArray[4] = new int[] { row + 1, column + 2 };
            jaggedArray[5] = new int[] { row + 1, column - 2 };
            jaggedArray[6] = new int[] { row + 2, column - 1 };
            jaggedArray[7] = new int[] { row + 2, column - 1 };

            return jaggedArray;
        }

        private static void PrintBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    Console.Write(board[row, column] + " ");
                }
                Console.WriteLine();
            }
        }


        private static void FillBoard(char[,] board, int boardSize)
        {
            for (int i = 0; i < boardSize; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    board[i, j] = line[j];
                }
            }
        }
    }
}
