using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedFibonacci = int.Parse(Console.ReadLine());

            long number = GetFibonacci(wantedFibonacci - 1);

            Console.WriteLine(number);
        }

        private static long GetFibonacci(int wantedFibonacci)
        {
            if (wantedFibonacci <= 1)
            {
                return 1;
            }

            return GetFibonacci(wantedFibonacci - 1) + GetFibonacci(wantedFibonacci - 2);
        }
    }
}
