using System;

namespace BubbleSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedSmallList = { 3, 1, 2 };
            int[] unsortedBigList = { 10, 4, 6, 9, 5, 2, 3, 1, 8, 7 };

            BubbleSort bubbleSort = new BubbleSort();
            int[] sortedList = bubbleSort.SortList(unsortedBigList);

            Console.WriteLine(string.Join(" ", sortedList));
        }
    }
}
