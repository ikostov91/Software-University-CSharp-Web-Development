using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static void Main()
        {
            var sum = double.Parse(Console.ReadLine());
            double levs;
            var currentCurrency = Console.ReadLine();
            var convertTo = Console.ReadLine();
            switch (currentCurrency)
            {
                case "BGN":
                    switch (convertTo)
                    {
                        case "USD": Console.WriteLine(Math.Round(sum / 1.79549, 2) + " USD"); break;
                        case "EUR": Console.WriteLine(Math.Round(sum / 1.95583, 2) + " EUR"); break;
                        case "GBP": Console.WriteLine(Math.Round(sum / 2.53405, 2) + " GBP"); break;
                    } break;
                case "EUR":
                    levs = sum * 1.95583;
                    switch (convertTo)
                    {
                        case "BGN": Console.WriteLine(Math.Round(levs, 2) + " BGN"); break;
                        case "USD": Console.WriteLine(Math.Round(levs / 1.95583, 2) + " USD"); break;
                        case "GBP": Console.WriteLine(Math.Round(levs / 2.53405, 2) + " GBP"); break;
                    } break;
                case "USD":
                    levs = sum * 1.79549;
                    switch (convertTo)
                    {
                        case "BGN": Console.WriteLine(Math.Round(levs, 2) + " BGN"); break;
                        case "EUR": Console.WriteLine(Math.Round(levs / 1.95583, 2) + " EUR"); break;
                        case "GBP": Console.WriteLine(Math.Round(levs / 2.53405, 2) + " GBP"); break;
                    } break;
                case "GBP":
                    levs = sum * 2.53405;
                    switch (convertTo)
                    {
                        case "BGN": Console.WriteLine(Math.Round(levs, 2) + " BGN"); break;
                        case "EUR": Console.WriteLine(Math.Round(levs / 1.95583, 2) + " EUR"); break;
                        case "USD": Console.WriteLine(Math.Round(levs / 1.79549, 2) + " USD"); break;
                    } break;
            }
        }
    }
}
