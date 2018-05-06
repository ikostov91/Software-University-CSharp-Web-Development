using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Box<int>> boxes = new List<Box<int>>();

        int numberOfIntegers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfIntegers; i++)
        {
            int value = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(value);
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

