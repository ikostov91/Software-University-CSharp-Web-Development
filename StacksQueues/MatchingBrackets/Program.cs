using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stackIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stackIndexes.Push(i);
                }

                if (expression[i] == ')')
                {
                    int startIndex = stackIndexes.Pop();
                    int endIndex = i;

                    int stringLength = GetStringLength(startIndex, endIndex);

                    Console.WriteLine(expression.Substring(startIndex, stringLength));
                }
            }
        }

        private static int GetStringLength(int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;
            return length;
        }
    }
}
