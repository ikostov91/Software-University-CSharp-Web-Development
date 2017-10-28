using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtrackSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Console.ReadLine();

            int index = filepath.LastIndexOf(@"\");

            string filename = filepath.Substring(index + 1);

            Console.WriteLine(filename);
        }
    }
}
