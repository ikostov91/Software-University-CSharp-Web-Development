using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> textVersions = new Stack<string>();
            textVersions.Push(text);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentOperation = Console.ReadLine().Split();

                int operationType = int.Parse(currentOperation[0]);

                switch (operationType)
                {
                    case 1:

                        text += currentOperation[1];
                        textVersions.Push(text);
                        break;
                    case 2:
                        int elementsToRemove = int.Parse(currentOperation[1]);
                        text = text.Remove(text.Length - elementsToRemove, elementsToRemove);
                        textVersions.Push(text);
                        break;
                    case 3:
                        int index = int.Parse(currentOperation[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        textVersions.Pop();
                        text = textVersions.Peek();
                        break;
                }
            }
        }
    }
}
