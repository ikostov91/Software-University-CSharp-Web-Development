using System;

public class Program
{
    static void Main(string[] args)
    {
        var spy = new Spy();
        var result = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(result);
    }
}

