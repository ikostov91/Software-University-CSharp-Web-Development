using System;

class Program
{
    static void Main(string[] args)
    {
        MathOperations mo = new MathOperations();
        Console.WriteLine(mo.Add(3,2));
        Console.WriteLine(mo.Add(1.5,1.5,2.0));
        Console.WriteLine(mo.Add(1.2m, 2.8m, 1.0m));
    }
}

