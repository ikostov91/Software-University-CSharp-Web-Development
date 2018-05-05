using System;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalRows = int.Parse(Console.ReadLine());

            char[][] room = new char[totalRows][];
            int rowLength = 0;

            for (int row = 0; row < totalRows; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }
            rowLength = room[0].Length;

            char[] directions = Console.ReadLine().ToCharArray();

            int[] playerPosition = GetPlayerPosition(room, rowLength);
            int[] nikoladzePosition = GetNikoladzePosition(room, rowLength);
            bool isPlayerSeen = CheckIfPlayerIsSeenByEnemy(room, rowLength, playerPosition);
            bool isPlayerOnSameRowAsNikoladze = CheckIfPlayerAndNikoladzeAreOnSameRow(playerPosition, nikoladzePosition);

            if (!isPlayerSeen && !isPlayerOnSameRowAsNikoladze)
            {
                foreach (var direction in directions)
                {
                    playerPosition = GetPlayerPosition(room, rowLength);
                    isPlayerSeen = CheckIfPlayerIsSeenByEnemy(room, rowLength, playerPosition);
                    if (isPlayerSeen)
                    {
                        Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                        room[playerPosition[0]][playerPosition[1]] = 'X';
                        playerPosition = GetPlayerPosition(room, rowLength);
                        room[playerPosition[0]][playerPosition[1]] = '.';
                        PrintRoom(room, rowLength);
                        return;
                    }
                    MoveEnemies(room, rowLength);
                    string result = MovePlayer(room, rowLength, playerPosition, direction, nikoladzePosition);
                    if (result == "win")
                    {
                        break;
                    }
                }
            }
            else
            {
                if (isPlayerOnSameRowAsNikoladze && !isPlayerSeen)
                {
                    Console.WriteLine("Nikoladze killed!");
                    room[nikoladzePosition[0]][nikoladzePosition[1]] = 'X';
                    PrintRoom(room, rowLength);
                    return;
                }

                if (isPlayerSeen && !isPlayerOnSameRowAsNikoladze)
                {
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    room[playerPosition[0]][playerPosition[1]] = 'X';
                    playerPosition = GetPlayerPosition(room, rowLength);
                    room[playerPosition[0]][playerPosition[1]] = '.';
                    PrintRoom(room, rowLength);
                    return;
                }
            }

            Console.WriteLine("Nikoladze killed!");
            room[nikoladzePosition[0]][nikoladzePosition[1]] = 'X';
            PrintRoom(room, rowLength);
        }

        private static bool CheckIfPlayerAndNikoladzeAreOnSameRow(int[] playerPosition, int[] nikoladzePosition)
        {
            if (playerPosition[0] == nikoladzePosition[0])
            {
                return true;
            }

            return false;
        }

        private static int[] GetNikoladzePosition(char[][] room, int rowLength)
        {
            int[] position = new int[2];
            bool isFound = false;

            for (int i = 0; i < room.GetLength(0); i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (room[i][j] == 'N')
                    {
                        position[0] = i;
                        position[1] = j;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return position;
        }

        private static string MovePlayer(char[][] room, int rowLength, int[] playerPosition, char direction, int[] nikoladzePosition)
        {
            int[] newPosition = new int[2];

            switch (direction)
            {
                case 'U':
                    newPosition[0] = playerPosition[0] - 1;
                    newPosition[1] = playerPosition[1];
                    break;
                case 'D':
                    newPosition[0] = playerPosition[0] + 1;
                    newPosition[1] = playerPosition[1];
                    break;
                case 'L':
                    newPosition[0] = playerPosition[0];
                    newPosition[1] = playerPosition[1] - 1;
                    break;
                case 'R':
                    newPosition[0] = playerPosition[0];
                    newPosition[1] = playerPosition[1] + 1;
                    break;
                case 'W':
                    newPosition[0] = playerPosition[0];
                    newPosition[1] = playerPosition[1];
                    break;
            }

            room[playerPosition[0]][playerPosition[1]] = '.';
            room[newPosition[0]][newPosition[1]] = 'S';

            if (newPosition[0] == nikoladzePosition[0])
            {
                return "win";
            }

            return "continue";
        }

        private static int[] GetPlayerPosition(char[][] room, int rowLength)
        {
            int[] position = new int[2];
            bool isFound = false;

            for (int i = 0; i < room.GetLength(0); i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (room[i][j] == 'S')
                    {
                        position[0] = i;
                        position[1] = j;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return position;
        }

        private static bool CheckIfPlayerIsSeenByEnemy(char[][] room, int rowLength, int[] playerPosition)
        {
            int row = playerPosition[0];
            int column = playerPosition[1];

            for (int i = column + 1; i < rowLength; i++)
            {
                if (room[row][i] == 'd')
                {
                    return true;
                }
            }

            for (int i = column - 1; i >= 0; i--)
            {
                if (room[row][i] == 'b')
                {
                    return true;
                }
            }

            return false;
        }

        private static void MoveEnemies(char[][] room, int rowLength)
        {
            for (int i = 0; i < room.GetLength(0); i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (room[i][j] == 'b')
                    {
                        if (j == rowLength - 1)
                        {
                            room[i][j] = 'd';
                        }
                        else
                        {
                            room[i][j] = '.';
                            room[i][j + 1] = 'b';
                        }
                        break;
                    }

                    if (room[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            room[i][j] = 'b';
                        }
                        else
                        {
                            room[i][j] = '.';
                            room[i][j - 1] = 'd';
                        }
                        break;
                    }
                }
            }
        }

        private static void PrintRoom(char[][] room, int rowLength)
        {
            for (int i = 0; i < room.GetLength(0); i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write(room[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
