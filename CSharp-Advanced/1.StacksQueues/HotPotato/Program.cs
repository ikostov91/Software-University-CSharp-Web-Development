using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ');
            int tossLimit = int.Parse(Console.ReadLine());

            Queue<string> queueChildren = new Queue<string>(children);

            while (queueChildren.Count != 1)
            {
                for (int tossCounter = 1; tossCounter < tossLimit; tossCounter++)
                {
                    queueChildren.Enqueue(queueChildren.Dequeue());
                }

                Console.WriteLine($"Removed {queueChildren.Peek()}");
                queueChildren.Dequeue();
            }

            Console.WriteLine($"Last is {queueChildren.Dequeue()}");
        }
    }
}
