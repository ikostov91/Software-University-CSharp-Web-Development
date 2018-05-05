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

            List<string> pricesWithVAT = prices.Select(y => addVAT(y)).Select(y => $"{y:F2}").ToList();

            Console.WriteLine(String.Join(Environment.NewLine, pricesWithVAT));
        }
    }
}
