using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulatingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello";
            string s2 = "Hello";

            //Console.WriteLine(s1.CompareTo(s2));
            Console.WriteLine(string.Compare(s1, s2, false));
            //Console.WriteLine(string.CompareOrdinal(s1, s2));
        }
    }
}
