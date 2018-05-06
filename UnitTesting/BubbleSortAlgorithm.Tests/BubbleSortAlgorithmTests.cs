using NUnit.Framework;
using System;

namespace BubbleSortAlgorithm.Tests
{
    [TestFixture]
    public class BubbleSortAlgorithmTests
    {
        private int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7, 8 };

        private BubbleSort sorter;

        [Test]
        [TestCase(6, 2, 5, 8, 1, 3, 7, 4)]
        [TestCase(8, 7, 6, 5, 4, 3, 2, 1)]
        public void AlgorithmSortsList(params int[] inputToSort)
        {
            sorter = new BubbleSort();
            int[] sortedNumbers = sorter.SortList(inputToSort);
            CollectionAssert.AreEqual(expectedResult, sortedNumbers);
        }
    }
}
