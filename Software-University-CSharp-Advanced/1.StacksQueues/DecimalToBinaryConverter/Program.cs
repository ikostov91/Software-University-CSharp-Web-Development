using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());

            if (decimalNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Stack<int> stack = new Stack<int>();

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2;
                decimalNumber /= 2;

                stack.Push(remainder);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
