using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            ExecuteCommands(people);
            PrintPeopleComing(people);
        }

        private static void PrintPeopleComing(List<string> people)
        {
            if (people.Any())
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void ExecuteCommands(List<string> people)
        {
            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string criteria = parameters[1];

                switch (criteria)
                {
                    case "StartsWith":
                        ForEach(parameters[0], people, n => n.StartsWith(parameters[2]));
                        break;
                    case "EndsWith":
                        ForEach(parameters[0], people, n => n.EndsWith(parameters[2]));
                        break;
                    case "Length":
                        ForEach(parameters[0], people, n => n.Length <= int.Parse(parameters[2]));
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void ForEach(string operation, List<string> people, Func<string, bool> Func)
        {
            for (int i = people.Count - 1; i >= 0; i--)
            {
                if (Func(people[i]))
                {
                    switch (operation)
                    {
                        case "Double":
                            people.Insert(i, people[i]);
                            break;
                        case "Remove":
                            people.RemoveAt(i);
                            break;
                    }
                }
            }
        }
    }
}
