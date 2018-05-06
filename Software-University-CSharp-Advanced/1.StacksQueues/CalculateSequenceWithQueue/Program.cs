using System;
using System.Collections.Generic;

namespace CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(N);

            for (int i = 0; i < 50; i++)
            {
                long current = queue.Dequeue();
                Console.Write($"{current} ");

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
