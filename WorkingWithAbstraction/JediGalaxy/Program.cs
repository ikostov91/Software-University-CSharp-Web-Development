using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Galaxy galaxy = new Galaxy(Console.ReadLine());

        string command;
        long sum = 0;

        while ((command = Console.ReadLine())!= "Let the Force be with you")
        {
            string ivoStartPosition = Console.ReadLine();
            string evilPosition = Console.ReadLine();

            galaxy.DestroyStars(evilPosition);
            sum = galaxy.SumScore(ivoStartPosition);
        }

        Console.WriteLine(sum);
    }
}

