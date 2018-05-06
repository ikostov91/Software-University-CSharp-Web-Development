using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listIterator = null;

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split(new char[] { ' ' });

            switch (commandArgs[0])
            {
                case "Create":
                    listIterator = new ListyIterator<string>(commandArgs.Skip(1).ToArray());
                    break;
                case "Move":
                    Console.WriteLine(listIterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(listIterator.HasNext());
                    break;
                case "Print":
                    try
                    {
                        listIterator.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}

