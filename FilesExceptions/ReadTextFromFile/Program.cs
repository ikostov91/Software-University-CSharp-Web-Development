using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("text.txt");
            Console.WriteLine(text);

            File.Delete("text.txt");

            text = "Replaced string!";

            File.WriteAllText("text.txt", text);
        }
    }
}
