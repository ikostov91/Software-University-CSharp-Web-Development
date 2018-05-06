using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IList<Box<string>> elementsList = new List<Box<string>>();
        int elementsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < elementsCount; i++)
        {
            string element = Console.ReadLine();
            elementsList.Add(new Box<string>(element));
        }

        string elementToCompare = Console.ReadLine();

        Console.WriteLine(CountGreaterElements(elementsList, elementToCompare));
    }

    static int CountGreaterElements<T>(IEnumerable<Box<T>> list, T element)
        where T : IComparable<T>
    {
        int count = 0;

        foreach (var box in list)
        {
            if (box.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }
}

