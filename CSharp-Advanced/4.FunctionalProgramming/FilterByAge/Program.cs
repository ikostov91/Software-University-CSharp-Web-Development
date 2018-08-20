using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        { 
            var people = new Dictionary<string, int>();
            people = PopulateDictionary(people);

            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            
            var filterePeople = FilterDictionary(people, condition, ageCondition);

            PrintPeople(filterePeople, format);
        }

        private static Dictionary<string, int> PopulateDictionary(Dictionary<string, int> people)
        {
            int pairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairs; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(name, age);
            }

            return people;
        }

        private static void PrintPeople(Dictionary<string, int> filterePeople, string format)
        {
            switch (format)
            {
                case "name":
                    foreach (var person in filterePeople)
                    {
                        Console.WriteLine(person.Key);
                    }
                    break;
                case "age":
                    foreach (var person in filterePeople)
                    {
                        Console.WriteLine(person.Value);
                    }
                    break;
                case "name age":
                    foreach (var person in filterePeople)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                    break;
            }
        }

        private static Dictionary<string, int> FilterDictionary(Dictionary<string, int> people, string condition, int ageCondition)
        {
            Dictionary<string, int> filteredPeople = new Dictionary<string, int>();

            Func<string, bool> olderCondition = text => text == "older";

            if (olderCondition(condition))
            {
                foreach (var person in people)
                {
                    if (person.Value >= ageCondition)
                    {
                        filteredPeople.Add(person.Key, person.Value);
                    }
                } 
            }
            else
            {
                foreach (var person in people)
                {
                    if (person.Value < ageCondition)
                    {
                        filteredPeople.Add(person.Key, person.Value);
                    }
                }
            }

            return filteredPeople;
        }
    }
}

