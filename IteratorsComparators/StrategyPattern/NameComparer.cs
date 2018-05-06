using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
        {
            // result = x.Name.ToLower().ElementAt(0).CompareTo(y.Name.ToLower().ElementAt(0));

            result = String.Compare(x.Name.First().ToString(), y.Name.First().ToString(), true);
        }

        return result;
    }
}

