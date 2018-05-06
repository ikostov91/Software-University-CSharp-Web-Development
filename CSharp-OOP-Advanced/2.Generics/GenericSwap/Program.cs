using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Box<string>> boxes = new List<Box<string>>();

        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string value = Console.ReadLine();
            Box<string> box = new Box<string>(value);
            boxes.Add(box);
        }

        int[] swapCommand = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Swap<string>.SwapValues(boxes, swapCommand[0], swapCommand[1]);

        foreach (var box in boxes)
        {
            Console.WriteLine(box);
        }
    }
}

