using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedDatabase.Tests
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person first, Person second)
        {
            return first.Id.Equals(second.Id) && (first.Username == second.Username);
        }

        public int GetHashCode(Person person)
        {
            return new { person.Username, person.Id }.GetHashCode();
        }
    }
}
