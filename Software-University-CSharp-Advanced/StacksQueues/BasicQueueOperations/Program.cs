using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();
            int elementsToEnqueue = input[0];
            int elementsToDequeue = input[1];
            int elementToSearchFor = input[2];

            EnqueueElements(queue, elementsToEnqueue, secondInput);
            DequeueElements(queue, elementsToDequeue);

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            bool isElementPresent = CheckIfElementIsInQueue(queue, elementToSearchFor);

            if (isElementPresent)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }

        private static bool CheckIfElementIsInQueue(Queue<int> queue, int elementToSearchFor)
        {
            if (queue.Contains(elementToSearchFor))
            {
                return true;
            }

            return false;
        }

        private static void EnqueueElements(Queue<int> queue, int elementsToEnqueue, int[] secondInput)
        {
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(secondInput[i]);
            }
        }

        private static void DequeueElements(Queue<int> queue, int elementsToDequeue)
        {
            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }
        }
    }
}
