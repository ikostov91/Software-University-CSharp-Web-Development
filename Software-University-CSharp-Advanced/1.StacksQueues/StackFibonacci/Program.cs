using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedFibonacci = int.Parse(Console.ReadLine());

            if (wantedFibonacci == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            Stack<long> fibonacciNumbers = new Stack<long>();
            fibonacciNumbers.Push(0);
            fibonacciNumbers.Push(1);

            while (fibonacciNumbers.Count != wantedFibonacci + 1)
            {
                long secondNumber = fibonacciNumbers.Pop();
                long firstNumber = fibonacciNumbers.Peek();

                fibonacciNumbers.Push(secondNumber);

                long currentFibonacci = firstNumber + secondNumber;

                fibonacciNumbers.Push(currentFibonacci);
            }

            Console.WriteLine(fibonacciNumbers.Pop());
        }
    }
}
