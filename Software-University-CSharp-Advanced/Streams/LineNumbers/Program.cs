using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("text.txt"))
            {
                using (var streamWriter = new StreamWriter("modifiedText.txt"))
                {
                    int lineCounter = 0;

                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lineCounter++;
                        line = $"Line{lineCounter}: " + line;

                        streamWriter.WriteLine(line);
                    }
                }
            }
        }
    }
}
