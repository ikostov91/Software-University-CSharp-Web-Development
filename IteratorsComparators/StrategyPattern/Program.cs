using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> nameSortedSet = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> ageSortedSet = new SortedSet<Person>(new AgeComparer());

        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 1; i <= peopleCount; i++)
        {
            string[] nameAge = Console.ReadLine().Split(' ').ToArray();
            string name = nameAge[0];
            int age = int.Parse(nameAge[1]);

            Person person = new Person(name, age);
            nameSortedSet.Add(person);
            ageSortedSet.Add(person);
        }

        foreach (var person in nameSortedSet)
        {
            Console.WriteLine(person);
        }

        foreach (var person in ageSortedSet)
        {
            Console.WriteLine(person);
        }
    }
}

