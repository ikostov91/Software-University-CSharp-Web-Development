using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Numerics;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            char[,] lair = new char[size[0],size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size[1]; j++)
                {
                    lair[i, j] = input[j];
                }
            }

            int[] playerLocation = FindPlayer(lair);

            char[] commands = Console.ReadLine().ToCharArray();

            string gameEnd = "";
            bool gameOver = false;

            foreach (var command in commands)
            {
                PrintLair(lair);

                playerLocation = FindPlayer(lair);

                string moveResult = MovePlayer(lair, command, playerLocation);

                if (moveResult == "win" || moveResult == "dead")
                {
                    gameEnd = moveResult;
                    gameOver = true;
                }

                ExpandBunnies(lair);
                playerLocation = FindPlayer(lair);

                if (lair[playerLocation[0],playerLocation[1]] == 'B')
                {
                    gameEnd = "dead";
                    gameOver = true;
                }

                if (gameOver)
                {
                    break;
                }
            }

            PrintLair(lair);

            Console.WriteLine($"{gameEnd}: {playerLocation[0]} {playerLocation[1]}");
        }

        private static void ExpandBunnies(char[,] lair)
        {
            string isDead = "";

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (lair[i,j] == 'B')
                    {
                        //if (lair[i+1,j] == 'P' || lair[i-1,j] == 'P' || lair[i,j+1] == 'P' || lair[i,j-1] == 'P')
                        //{
                        //    isDead = "dead";
                        //}
                        ExpandBunnyCell(lair, i, j);
                    }
                }
            }
        }

        private static void ExpandBunnyCell(char[,] lair, int i, int j)
        {
            if (i - 1 >= 0)
            {
                lair[i - 1, j] = 'B';
            }

            if (i + 1 <= lair.GetLength(0) - 1)
            {
                lair[i + 1, j] = 'B';
            }

            if (j - 1 >= 0)
            {
                lair[i, j - 1] = 'B';
            }

            if (j + 1 <= lair.GetLength(1) - 1)
            {
                lair[i, j + 1] = 'B';
            }
        }

        private static string MovePlayer(char[,] lair, char direction, int[] currentLocation)
        {
            int i = currentLocation[0];
            int j = currentLocation[1];

            switch (direction)
            {
                case 'U':
                    if (i - 1 < 0)
                    {
                        return "win";
                    }
                    else if (lair[i - 1, j] == 'B')
                    {
                        char temp = lair[i, j];
                        lair[i,j] = lair[i - 1, j];
                        lair[i-1, j] = temp;
                        return "dead";
                    }
                    else
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i - 1, j];
                        lair[i - 1, j] = temp;
                    }
                    break;
                case 'D':
                    if (i + 1 > lair.GetLength(1) - 1)
                    {
                        return "win";
                    }
                    else if (lair[i + 1, j] == 'B')
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i + 1, j];
                        lair[i + 1, j] = temp;
                        return "dead";
                    }
                    else
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i + 1, j];
                        lair[i + 1, j] = temp;
                    }
                    break;
                case 'L':
                    if (j - 1 < 0)
                    {
                        return "win";
                    }
                    else if (lair[i, j - 1] == 'B')
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i, j - 1];
                        lair[i, j - 1] = temp;
                        return "dead";
                    }
                    else
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i, j - 1];
                        lair[i, j - 1] = temp;
                    }
                    break;
                case 'R':
                    if (j + 1 > lair.GetLength(1) - 1)
                    {
                        return "win";
                    }
                    else if (lair[i, j + 1] == 'B')
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i, j + 1];
                        lair[i, j + 1] = temp;
                        return "dead";
                    }
                    else
                    {
                        char temp = lair[i, j];
                        lair[i, j] = lair[i, j + 1];
                        lair[i, j + 1] = temp;
                    }
                    break;
            }

            return "continue";
        }

        private static int[] FindPlayer(char[,] lair)
        {
            int[] coordinates = new int[2];
            bool isFound = false;

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (lair[i,j] == 'P')
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;

                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return coordinates;
        }

        private static void PrintLair(char[,] lair)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
