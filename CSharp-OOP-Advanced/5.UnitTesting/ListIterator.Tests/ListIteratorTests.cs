using NUnit.Framework;
using System;

namespace ListIterator.Tests
{
    [TestFixture]
    public class ListIteratorTests
    {
        private string[] input = { "Pesho", "Gosho" };
        private ListIterator iterator;

        [Test]
        public void ExceptionIsThrownWhenInputIsNull()
        {
            string[] nullInput = null;
            Assert.Throws<ArgumentNullException>(() => new ListIterator(nullInput));
        }

        [Test]
        public void IteratorIsCreatedSuccesfullyWithEmptyInput()
        {
            iterator = new ListIterator();
            Assert.That(() => iterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void IterstorIsCreatedSuccesfullyWithItems()
        {
            iterator = new ListIterator(input);
            Assert.That(() => iterator.Print(), Is.EqualTo("Pesho"));
        }

        [Test]
        public void MoveCommandMovesInternalIndexToNextPosition()
        {
            iterator = new ListIterator(input);
            Assert.That(() => iterator.Move(), Is.EqualTo(true));
        }

        [Test]
        public void MoveCommandReturnsFalseAtEndOfList()
        {
            iterator = new ListIterator(input);
            iterator.Move();
            Assert.That(() => iterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void PrintCommandThrowsExceptionWhenListIsEmpty()
        {
            iterator = new ListIterator();
            Assert.That(() => iterator.Print(), Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
        }

        [Test]
        public void PrintCommandPrintsLastIndexedName()
        {
            iterator = new ListIterator(input);
            iterator.Move();
            Assert.That(() => iterator.Print(), Is.EqualTo("Gosho"));
        }

        [Test]
        public void LastNameInListIsStillPrintedWhenMoveCommandReturnsFalse()
        {
            iterator = new ListIterator(input);
            for (int i = 1; i <= 3; i++)
            {
                iterator.Move();
            }
            Assert.That(() => iterator.Print(), Is.EqualTo("Gosho"));
        }

        [Test]
        public void HasNextCommandReturnsTrueIfInternalIndexIsNotAtTheEndOfTheList()
        {
            iterator = new ListIterator(input);
            Assert.That(() => iterator.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void HasNextCommandReturnsFalseWhenIndexIsAtTheEndOfTheList()
        {
            iterator = new ListIterator(input);
            iterator.Move();
            Assert.That(() => iterator.HasNext(), Is.EqualTo(false));
        }
    }
}
