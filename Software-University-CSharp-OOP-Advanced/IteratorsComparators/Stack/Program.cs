using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>(new List<int>());

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandParams = input.Split(new char[] { ' ', ',', }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            switch (commandParams[0])
            {
                case "Push":
                    for (int i = 1; i < commandParams.Length; i++)
                    {
                        stack.Push(int.Parse(commandParams[i]));
                    }
                    break;
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid Command");
            }
        }

        for (int i = 1; i <= 2; i++)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

