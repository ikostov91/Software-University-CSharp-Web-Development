using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            //Stack<char> stack = new Stack<char>(input.ToCharArray());

            foreach (var character in input)
            {
                stack.Push(character);
            }

            string reversed = String.Empty;

            while (stack.Count > 0)
            {
                //Console.Write(stack.Pop().ToString());
                reversed = reversed + stack.Pop();
            }

            Console.WriteLine(reversed);
        }
    }
}
