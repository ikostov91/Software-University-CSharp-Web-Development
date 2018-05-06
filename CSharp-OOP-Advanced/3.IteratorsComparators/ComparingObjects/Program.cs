using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] parameters = input.Split(' ');
            string name = parameters[0];
            int age = int.Parse(parameters[1]);
            string town = parameters[2];

            Person person = new Person(name, age, town);
            people.Add(person);
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        int equalPeople = 0;
        int nonEqualPeople = 0;
        int totalPeople = people.Count;

        Person desiredPerson = people[index];

        foreach (var person in people)
        {
            if (person.CompareTo(desiredPerson) == 0)
            {
                equalPeople++;
            }
            else
            {
                nonEqualPeople++;
            }
        }

        if (equalPeople == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeople} {nonEqualPeople} {totalPeople}");
        }
    }
}

