using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        CommandParser parser = new CommandParser();

        while (true)
        { 
            parser.ParseCommand(Console.ReadLine());
        }
    }
}

