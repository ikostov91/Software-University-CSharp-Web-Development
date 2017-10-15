using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "Odd" && input != "Even")
            {
                string[] command = input.Split(' ').ToArray();

                if (command[0] == "Delete")
                {
                    int number = int.Parse(command[1]);
                    for (int i = 0; i < listNumbers.Count; i++)
                    {
                        if (listNumbers[i] == number)
                        {
                            listNumbers.Remove(number);
                            i -= 1;
                        }
                    }
                }

                if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    listNumbers.Insert(index, number);
                }

                input = Console.ReadLine();
            }

            PrintList(listNumbers, input);
        }

        private static void PrintList(List<int> listNumbers, string nums)
        {
            if (nums == "Odd")
            {
                for (int i = 0; i < listNumbers.Count; i++)
                {
                    if (listNumbers[i] % 2 != 0)
                    {
                        Console.Write(listNumbers[i] + " ");
                    }
                }
            }
            else
            {
                for (int i = 0; i < listNumbers.Count; i++)
                {
                    if (listNumbers[i] % 2 == 0)
                    {
                        Console.Write(listNumbers[i] + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
