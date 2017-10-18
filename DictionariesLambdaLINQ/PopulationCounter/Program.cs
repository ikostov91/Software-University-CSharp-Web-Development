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
            Dictionary<string, Dictionary<string, int>> populationData = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] data = input.Split('|').ToArray();
                string city = data[0];
                Console.WriteLine(city);
                string country = data[1];
                Console.WriteLine(country);
                int population = int.Parse(data[2]);
                Console.WriteLine(population);

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
                    populationData.Add(country, new Dictionary<string, int>());
                    populationData[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            foreach (var country in populationData.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                int totalPopulation = 0;
                totalPopulation = country.Value.Sum(total => total.Value);

                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
