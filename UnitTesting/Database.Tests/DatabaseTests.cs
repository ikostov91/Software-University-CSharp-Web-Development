using NUnit.Framework;
using System;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DatabaseIsCreatedWithInputItems()
        {
            Database db = new Database(1, 2, 3, 4);
            Assert.That(db[0], Is.EqualTo(1));
        }

        [Test]
        public void DatabaseIsCreatedEmptyWithNoInputItems()
        {
            Database db = new Database();
            Assert.That(db[0], Is.EqualTo(0));
        }

        [Test]
        public void ExceptionIsThrownWhenInputItemsExceedDatabaseCapacity()
        {
            int[] inputItems = Enumerable.Repeat(1, 17).ToArray();
            Assert.That(() => new Database(inputItems), Throws.InvalidOperationException.With.Message.EqualTo("Input exceeds capacity"));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenDatabaseIsFull()
        {
            int[] inputItems = Enumerable.Repeat(2, 16).ToArray();
            Database db = new Database(inputItems);
            Assert.That(() => db.Add(1), Throws.InvalidOperationException.With.Message.EqualTo("Database is full"));
        }

        [Test]
        public void AddMethodAddsItemToDatabaseSuccesfully()
        {
            Database db = new Database(1, 2, 3, 4, 5);
            db.Add(6);
            Assert.That(db[5], Is.EqualTo(6));
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenDatabaseIsEmpty()
        {
            Database db = new Database();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Database is empty"));
        }

        [Test]
        public void RemoveMethodRemovesLastItemInNonEmptyDatabase()
        {
            Database db = new Database(1, 2, 3, 4, 5, 6);
            db.Remove();
            Assert.That(db[5], Is.EqualTo(0));
        }

        [Test]
        public void FetchMethodGetsDatabaseItems()
        {
            Database db = new Database(1, 2, 3, 4, 5);
            int[] fetched = db.Fetch();
            int[] expected = { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, fetched);
        }
    }
}
