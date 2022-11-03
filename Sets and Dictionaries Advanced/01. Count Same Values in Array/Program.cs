using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine().Split(' ')
                .Select(double.Parse).ToList();
            Dictionary<double, int> dict = new Dictionary<double, int>();
            foreach(var item in list)
            {
                if(!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                dict[item]++;
            }
            foreach(var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
