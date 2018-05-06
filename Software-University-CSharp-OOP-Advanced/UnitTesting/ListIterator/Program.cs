using System;

namespace ListIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] list = {"Trolo", "Adada"};

            ListIterator iterator = new ListIterator(list);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (input)
                    {
                        case "Move":
                            iterator.Move();
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(iterator.Print());
                            break;
                        default:
                            Console.WriteLine("Invalid command!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
