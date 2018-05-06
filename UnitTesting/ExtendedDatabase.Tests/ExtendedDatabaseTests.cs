using NUnit.Framework;
using System;
using System.Linq;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private readonly Person expectedPerson = new Person(1, "Pesho");
        PersonComparer personComparer = new PersonComparer();

        [Test]
        public void DatabaseIsCreatedWithPersons()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"), new Person(2, "Joro"));
            Assert.IsTrue(this.personComparer.Equals(db[0], expectedPerson), "Actual person is not equal to expected");
        }

        [Test]
        public void DatabaseIsCreatedEmpty()
        {
            ExtendedDatabase db = new ExtendedDatabase();
            Assert.That(db[0], Is.EqualTo(null));
        }

        [Test]
        public void ExceptionIsThrownWhenInputIsLargerThanDatabaseCapacity()
        {
            Person[] input = Enumerable.Repeat(new Person(9, "Joro"), 17).ToArray();
            Assert.That(() => new ExtendedDatabase(input), Throws.InvalidOperationException.With.Message.EqualTo("Input exceeds capacity"));
        }

        [Test]
        public void ExceptionIsThrownWhenIdAlreadyExistInDatabase()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.That(() => db.Add(new Person(1, "Joro")), Throws.InvalidOperationException.With.Message.EqualTo("Person with this id already exists"));
        }

        [Test]
        public void ExceptionIsThrownWhenUsernameAlreadyExistInDatabase()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.That(() => db.Add(new Person(3, "Pesho")), Throws.InvalidOperationException.With.Message.EqualTo("Person with this username already exists"));
        }

        [Test]
        public void NewPersonIsSuccesfullyAddedToDatabase()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(2, "Joro"));
            db.Add(new Person(1, "Pesho"));
            Assert.IsTrue(personComparer.Equals(db[1], expectedPerson));
        }

        [Test]
        public void ExceptionIsThrownWhenNewPersonIsAddedToFullDatabase()
        {
            Person[] input = Enumerable.Repeat(new Person(4, "Gosho"), 16).ToArray();
            ExtendedDatabase db = new ExtendedDatabase(input);
            Assert.That(() => db.Add(new Person(6, "Stancho")), Throws.InvalidOperationException.With.Message.EqualTo("Database is full"));
        }

        [Test]
        public void ExceptionIsThrownWhemPersonIsRemovedFromEmptyDatabase()
        {
            ExtendedDatabase db = new ExtendedDatabase();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Database is empty"));
        }

        [Test]
        public void PersonIsSuccesfullyRemovedFromDatabase()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Tosho"), new Person(2, "Gancho"));
            db.Remove();
            Assert.That(db[1], Is.EqualTo(null));
        }

        [Test]
        public void ExceptionIsThrownWhenUsernameDoesNotExist()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.That(() => db.FindByUsername("Joro"), Throws.InvalidOperationException.With.Message.EqualTo("Person with this username does not exist"));
        }

        [Test]
        public void ExceptionIsThrownWhenUsernameInputIsNullOrEmpty()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null), "Username cannot be null");
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(string.Empty), "Username cannot be null");
        }

        [Test]
        public void UserFoundByUsernameIsSuccesfullyReturned()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.IsTrue(personComparer.Equals(expectedPerson, db.FindByUsername("Pesho")), "Existing user is not return");
        }

        [Test]
        public void ExceptionIsThrownIfIdDoesNotExist()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(2, "Joro"));
            Assert.That(() => db.FindById(4), Throws.InvalidOperationException.With.Message.EqualTo("Person with this id does not exist"));
        }

        [Test]
        public void ExceptionIsThrownWhenIdInputIsNegative()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void UserFoundByIdIsSuccesfullyReturned()
        {
            ExtendedDatabase db = new ExtendedDatabase(new Person(1, "Pesho"));
            Assert.IsTrue(personComparer.Equals(expectedPerson, db.FindById(1)));
        }
    }
}
