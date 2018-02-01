using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            Stack<char> stackParentheses = new Stack<char>();
            char lastParentheses;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    stackParentheses.Push(input[i]);
                }
                else
                {
                    switch (input[i])
                    {
                        case ')':
                            lastParentheses = stackParentheses.Pop();

                            if (lastParentheses != '(')
                            {
                                Console.WriteLine("NO");
                                Environment.Exit(0);
                            }
                            break;
                        case ']':
                            lastParentheses = stackParentheses.Pop();

                            if (lastParentheses != '[')
                            {
                                Console.WriteLine("NO");
                                Environment.Exit(0);
                            }
                            break;
                        case '}':
                            lastParentheses = stackParentheses.Pop();

                            if (lastParentheses != '{')
                            {
                                Console.WriteLine("NO");
                                Environment.Exit(0);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
