using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CityWeather> allCities = new Dictionary<string, CityWeather>();

            string pattern = @"(?<cityCode>[A-Z]{2})(?<temp>[0-9]+\.[0-9]*)(?<weather>[A-Za-z]+)";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                foreach (Match m in Regex.Matches(input, pattern))
                {
                    var city = m.Groups[1].Value;
                    var cityWeather = new CityWeather();
                    cityWeather.temperatyre = double.Parse(m.Groups[2].Value);
                    cityWeather.weather = m.Groups[3].Value;

                    if (!allCities.ContainsKey(city))
                    {
                        allCities.Add(city, cityWeather);
                    }
                    else
                    {
                        allCities[city] = cityWeather;
                    }
                }
            }

            foreach (var city in allCities.OrderBy(x => x.Value.temperatyre))
            {
                Console.WriteLine($"{city.Key} => {city.Value.temperatyre:F2} => {city.Value.weather}");
            }
        }
    }

    class CityWeather
    {
        public double temperatyre { get; set; }
        public string weather { get; set; }
    }
}
