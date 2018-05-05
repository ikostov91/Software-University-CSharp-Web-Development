using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> populationData = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] data = input.Split('|').ToArray();
                string city = data[0];
                string country = data[1];
                double population = double.Parse(data[2]);

                if (populationData.ContainsKey(country))
                {
                    if (populationData[country].ContainsKey(city))
                    {
                        populationData[country][city] += population;
                    }
                    else
                    {
                        populationData[country].Add(city, population);
                    }
                }
                else
                {
                    populationData.Add(country, new Dictionary<string, double>());
                    populationData[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            foreach (var country in populationData.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Sum(x => x.Value)})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}