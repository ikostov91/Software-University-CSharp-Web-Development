using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSortAlgorithm
{
    public class BubbleSort
    {
        public int[] SortList(params int[] input)
        {
            int[] listToSort = input;

            bool unsorted = true;

            while (unsorted)
            {
                unsorted = false;

                for (int i = 0; i < listToSort.Length - 1; i++)
                {
                    if (listToSort[i] > listToSort[i + 1])
                    {
                        int temp = listToSort[i];
                        listToSort[i] = listToSort[i + 1];
                        listToSort[i + 1] = temp;
                        unsorted = true;
                    }
                }
            }

            return listToSort;
        }
    }
}
