using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; private set; }

        public string Username { get; private set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Username}";
        }
    }
}
