using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < people; i++)
        {
            string[] currentPerson = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None).ToArray();

            Person person = new Person(currentPerson[0], int.Parse(currentPerson[1]));
            family.Members.Add(person);
        }

        Person oldestPerson = family.GetOldestMember(family.Members);

        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

