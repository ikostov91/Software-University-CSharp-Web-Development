using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(' ').ToArray();

            Stack<string> stack = new Stack<string>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                stack.Push(expression[i]);
            }

            while (stack.Count > 1)
            {
                int leftOperand = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());

                switch (sign)
                {
                    case "+": stack.Push((leftOperand + rightOperand).ToString()); break;
                    case "-": stack.Push((leftOperand - rightOperand).ToString()); break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
