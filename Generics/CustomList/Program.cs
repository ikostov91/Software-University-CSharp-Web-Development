using System;
using System.Linq;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> list = new CustomList<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] parameters = command.Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();

                switch (parameters[0])
                {
                    case "Add":
                        list.Add(parameters[1]);
                        break;
                    case "Remove":
                        list.Remove(int.Parse(parameters[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(parameters[1]));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(parameters[1]), int.Parse(parameters[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(list.CountGreaterThan(parameters[1]));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        Console.WriteLine(list.ToString());
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
        }
    }
}
