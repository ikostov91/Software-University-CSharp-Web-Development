using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();
            int elementsToPush = input[0];
            int elementsToPop = input[1];
            int elementToCheck = input[2];

            PushElements(stack, secondInput, elementsToPush);
            PopElements(stack, elementsToPop);

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            bool isNumberPresent = CheckIfNumberIsInStack(stack, elementToCheck);

            if (isNumberPresent)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }

        private static void PushElements(Stack<int> stack, int[] input, int elementsToPush)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int currentNumber = input[i];
                stack.Push(currentNumber);
            }
        }

        private static void PopElements(Stack<int> stack, int elementsToPop)
        {
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }
        }

        private static bool CheckIfNumberIsInStack(Stack<int> stack, int elementToCheck)
        {
            if (stack.Contains(elementToCheck))
            {
                return true;
            }

            return false;
        }
    }
}
