using System;

namespace KnightGameTrainerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[][] board = new char[boardSize][];

            for (int counter = 0; counter < boardSize; counter++)
            {
                board[counter] = Console.ReadLine().ToCharArray();
            }

            if (boardSize < 3)
            {
                Console.WriteLine(0);
                return;
            }

            int maxRow = 0;
            int maxColumn = 0;
            int maxAttackedPositions = 0;
            int countOfRemovedKnights = 0;

            do
            {
                if (maxAttackedPositions > 0)
                {
                    board[maxRow][maxColumn] = '0';
                    maxAttackedPositions = 0;
                    countOfRemovedKnights++;
                }

                int currentAttackPositions = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int column = 0; column < boardSize; column++)
                    {
                        if (board[row][column] == 'K')
                        {
                            currentAttackPositions = CalculateAttackedPositions(row, column, board);

                            if (currentAttackPositions > maxAttackedPositions)
                            {
                                maxAttackedPositions = currentAttackPositions;
                                maxRow = row;
                                maxColumn = column;
                            }
                        }
                    }
                }
            } while (maxAttackedPositions > 0);

            Console.WriteLine(countOfRemovedKnights);
        }

        private static int CalculateAttackedPositions(int row, int col, char[][] board)
        {
            int currentAttackPositions = 0;

            if (IsPositionAttacked(row - 2, col - 1, board)) currentAttackPositions++;
            if (IsPositionAttacked(row - 2, col + 1, board)) currentAttackPositions++;
            if (IsPositionAttacked(row - 1, col - 2, board)) currentAttackPositions++;
            if (IsPositionAttacked(row - 1, col + 2, board)) currentAttackPositions++;
            if (IsPositionAttacked(row + 1, col - 2, board)) currentAttackPositions++;
            if (IsPositionAttacked(row + 1, col + 2, board)) currentAttackPositions++;
            if (IsPositionAttacked(row + 2, col + 1, board)) currentAttackPositions++;
            if (IsPositionAttacked(row + 2, col - 1, board)) currentAttackPositions++;

            return currentAttackPositions;
        }

        private static bool IsPositionAttacked(int row, int column, char[][] board)
        {
            return IsPositionWithinBoard(row, column, board[0].Length) && board[row][column] == 'K';
        }

        private static bool IsPositionWithinBoard(int row, int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }
    }
}
