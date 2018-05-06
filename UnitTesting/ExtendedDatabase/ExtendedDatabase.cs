using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedDatabase
{
    public class ExtendedDatabase : IEnumerable<Person>
    {
        private const int ArrayCapacity = 16;

        private readonly Person[] databasePersons;
        private int currentIndex;

        public ExtendedDatabase(params Person[] inputPersons)
        {
            this.databasePersons = new Person[ArrayCapacity];

            if (inputPersons.Length > ArrayCapacity)
            {
                throw new InvalidOperationException("Input exceeds capacity");
            }

            this.currentIndex = 0;
            foreach (var item in inputPersons)
            {
                this.databasePersons[currentIndex] = item;
                currentIndex++;
            }
        }

        public Person this[int i]
        {
            get { return this.databasePersons[i]; }
        }

        public void Add(Person person)
        {
            if (this.currentIndex == ArrayCapacity)
            {
                throw new InvalidOperationException("Database is full");
            }

            if (this.databasePersons.Where(p => p != null).Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("Person with this id already exists");
            }

            if (this.databasePersons.Where(p => p != null).Any(p => p.Username == person.Username))
            {
                throw new InvalidOperationException("Person with this username already exists");
            }

            this.databasePersons[currentIndex] = person;
            currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            currentIndex--;
            this.databasePersons[currentIndex] = null;
        }

        public Person[] Fetch()
        {
            List<Person> fetchedPersons = new List<Person>();

            foreach (var person in this.databasePersons.Where(p => p != null))
            {
                fetchedPersons.Add(person);
            }

            return fetchedPersons.ToArray();
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be null");
            }

            if (!this.databasePersons.Where(p => p != null).Any(p => p.Username == username))
            {
                throw new InvalidOperationException("Person with this username does not exist");
            }

            return this.databasePersons.FirstOrDefault(p => p.Username == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative");
            }

            if (!this.databasePersons.Where(p => p != null).Any(p => p.Id == id))
            {
                throw new InvalidOperationException("Person with this id does not exist");
            }

            return this.databasePersons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            foreach (var person in this.databasePersons.Where(p => p != null))
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
