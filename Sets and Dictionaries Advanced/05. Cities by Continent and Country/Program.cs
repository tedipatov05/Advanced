using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if(!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                }
                Dictionary<string, List<string>> countries = dict[continent];
                if(!countries.ContainsKey(country))
                {
                    countries.Add(country, new List<string>());
                }
                countries[country].Add(city);

            }
            foreach(var continent in dict)
            {
                Console.WriteLine($"{continent.Key}:");
                Dictionary<string, List<string>> countries = continent.Value;
                foreach(var country in countries)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
