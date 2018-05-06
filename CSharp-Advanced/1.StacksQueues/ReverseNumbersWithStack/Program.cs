using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(input);

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
