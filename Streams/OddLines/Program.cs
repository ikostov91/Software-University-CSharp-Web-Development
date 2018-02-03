using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("text.txt"))
            {
                int lineCounter = 0;

                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(line);
                        lineCounter++;
                        continue;
                    }

                    lineCounter++;
                }
            }           
        }
    }
}
