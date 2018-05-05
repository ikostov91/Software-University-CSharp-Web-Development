using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] stones = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}

