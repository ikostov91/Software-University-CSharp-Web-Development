using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceString
{
    class Program
    {
        static void Main(string[] args)
        {
            string cocktail = "Vodka + Martini + Cherry";
            cocktail = cocktail.Replace("+", "and");
            Console.WriteLine(cocktail);
        }
    }
}
