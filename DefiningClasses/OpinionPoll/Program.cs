using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> listOfPersons = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None).ToArray();

                Person person = new Person(currentPerson[0], int.Parse(currentPerson[1]));
                listOfPersons.Add(person);
            }

            foreach (var person in listOfPersons.Where(x => x.Age > 30).OrderBy(y => y.Name))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
