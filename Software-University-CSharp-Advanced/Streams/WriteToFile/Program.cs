using System;
using System.IO;
using System.Linq;

namespace WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readStream = new StreamReader("Program.cs"))
            {
                using (var writeStream = new StreamWriter("reversed.txt"))
                {
                    string line;

                    while ((line = readStream.ReadLine()) != null)
                    {
                        string reversedLine = string.Empty;

                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            reversedLine = reversedLine + line[counter];
                        }
                        writeStream.WriteLine(reversedLine);

                        Console.WriteLine(reversedLine);
                    }
                }
            }
        }
    }
}
