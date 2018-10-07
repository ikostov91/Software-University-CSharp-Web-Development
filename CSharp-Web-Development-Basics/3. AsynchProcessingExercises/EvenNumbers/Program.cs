using System;
using System.Linq;
using System.Threading;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int min = range[0];
            int max = range[1];

            Thread thread = new Thread(() => PrintEvenNumbersInRange(min, max));
            thread.Start();
            Console.WriteLine("Thread working.....");

            thread.Join();
            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvenNumbersInRange(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
