using System;
using System.Linq;
using System.Text;

namespace DangerousFloor
{
    class Program
    {
        private const int boardSize = 8;

        static void Main(string[] args)
        {
            char[][] board = new char[boardSize][];

            for (int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END") break;
              
                string[] move = input.Split('-').ToArray();

                char pieceType = move[0][0];
                int startRow = int.Parse(move[0].Substring(1, 1));
                int startColumn = int.Parse(move[0].Substring(2, 1));

                int endRow = int.Parse(move[1].Substring(0, 1));
                int endColumn = int.Parse(move[1].Substring(1, 1));

                bool isPieceOnPosition = CheckIfPieceIsOnPosition(pieceType, startRow, startColumn, board);
                if (!isPieceOnPosition)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                bool isMoveValid = CheckIfMoveIsValid(pieceType, startRow, startColumn, endRow, endColumn, board);
                if (!isMoveValid)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                bool isPieceWithinBoard = CheckIfPieceStaysWithinBoard(endRow, endColumn, board);
                if (!isPieceWithinBoard)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[startRow][startColumn] = 'x';
                board[endRow][endColumn] = pieceType;

                //PrintBoard(board);
            }
        }

        private static bool CheckIfPieceStaysWithinBoard(int endRow, int endColumn, char[][] board)
        {
            return endRow >= 0 && endRow < boardSize && endColumn >= 0 && endColumn < boardSize;
        }

        private static bool CheckIfMoveIsValid(char pieceType, int startRow, int startColumn, int endRow, int endColumn, char[][] board)
        {
            bool isMoveValid = false;

            switch (pieceType)
            {
                case 'P':
                    isMoveValid = CheckPawnMove(startRow, startColumn, endRow, endColumn);
                    break;
                case 'K':
                    isMoveValid = CheckKingMove(startRow, startColumn, endRow, endColumn);
                    break;
                case 'R':
                    isMoveValid = CheckRookMove(startRow, startColumn, endRow, endColumn);
                    break;
                case 'B':
                    isMoveValid = CheckBishopMove(startRow, startColumn, endRow, endColumn);
                    break;
                case 'Q':
                    isMoveValid = CheckQueenMove(startRow, startColumn, endRow, endColumn);
                    break;
            }

            return isMoveValid;
        }

        private static bool CheckQueenMove(int startRow, int startColumn, int endRow, int endColumn)
        {
            if (CheckRookMove(startRow, startColumn, endRow, endColumn))
            {
                return true;
            }

            if (CheckBishopMove(startRow, startColumn, endRow, endColumn))
            {
                return true;
            }

            return false;
        }

        private static bool CheckBishopMove(int startRow, int startColumn, int endRow, int endColumn)
        {
            if (startRow == endRow || startColumn == endColumn)
            {
                return false;
            }

            if (Math.Abs(endRow - startRow) == Math.Abs(endColumn - startColumn))
            {
                return true;
            }

            return false;
        }

        private static bool CheckRookMove(int startRow, int startColumn, int endRow, int endColumn)
        {
            if (startRow == endRow || startColumn == endColumn)
            {
                return true;
            }

            return false;
        }

        private static bool CheckKingMove(int startRow, int startColumn, int endRow, int endColumn)
        {
            if (Math.Abs(endRow - startRow) <= 1 && Math.Abs(endColumn - startColumn) <= 1)
            {
                return true;
            }

            return false;
        }

        private static bool CheckPawnMove(int startRow, int startColumn, int endRow, int endColumn)
        {
            if (startColumn == endColumn && endRow == startRow - 1)
            {
                return true;
            }

            return false;
        }

        private static bool CheckIfPieceIsOnPosition(char pieceType, int row, int column, char[][] board)
        {
            if (board[row][column] == pieceType)
            {
                return true;
            }

            return false;
        }

        private static void PrintBoard(char[][] board)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    Console.Write(board[row][column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
