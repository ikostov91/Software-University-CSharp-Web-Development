using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(double.Parse)
                                                    .ToList();
            
            Func<double, double> addVAT = number => number + (number * 0.20);
            Func<double, string> toString = number => $"{number:F2}";

            List<string> pricesWithVAT = prices.Select(addVAT).Select(toString).ToList();

            Console.WriteLine(String.Join(Environment.NewLine, pricesWithVAT));
        }
    }
}
