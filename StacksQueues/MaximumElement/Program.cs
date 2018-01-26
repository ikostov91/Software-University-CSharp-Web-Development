using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> stackMax = new Stack<int>();
            stackMax.Push(int.MinValue);

            for (int i = 0; i < queries; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                switch (input[0])
                {
                    case "1":
                        int elementToPush = int.Parse(input[1]);
                        stack.Push(elementToPush);

                        if (elementToPush > stackMax.Peek())
                        {
                            stackMax.Push(elementToPush);
                        }
                        else
                        {
                            stackMax.Push(stackMax.Peek());
                        }
                        break;

                    case "2":
                        stack.Pop();
                        stackMax.Pop();
                        break;

                    case "3":
                        Console.WriteLine(stackMax.Peek());
                        break;
                }
            }
        }
    }
}
