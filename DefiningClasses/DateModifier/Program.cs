using System;

class Program
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        DateModifier dateModifier = new DateModifier();

        int daysDifference = dateModifier.CalculateDaysBetweenDates(firstDate, secondDate);
        Console.WriteLine(daysDifference);
    }
}

