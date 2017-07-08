using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterWithDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal ammount = decimal.Parse(Console.ReadLine());
            string firstCurrency = Console.ReadLine().ToLower();
            string secondCurrency = Console.ReadLine().ToLower();

            var currencies = new Dictionary<string, decimal>()
            {
                {"bgn", 1m},
                {"usd", 1.79549m},
                {"eur", 1.95583m},
                {"gbp", 2.53405m}
            };

            decimal result = (currencies[firstCurrency] / currencies[secondCurrency]) * ammount;

            Console.WriteLine("{0} {1}", Math.Round(result, 2), secondCurrency);
        }
    }
}
