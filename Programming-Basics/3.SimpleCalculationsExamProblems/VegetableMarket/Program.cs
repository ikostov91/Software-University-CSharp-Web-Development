using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPrice = double.Parse(Console.ReadLine());
            double fruitsPrice = double.Parse(Console.ReadLine());
            int vegetablesAmmount = int.Parse(Console.ReadLine());
            int fruitsAmmount = int.Parse(Console.ReadLine());
            double income = (vegetablesAmmount * vegetablesPrice + fruitsAmmount * fruitsPrice) / 1.94;
            Console.WriteLine(income);
        }
    }
}
