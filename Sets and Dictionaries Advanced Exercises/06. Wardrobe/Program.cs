using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();
            for(int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] colours = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = colours[0];
                string[] clothes = colours[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if(!dic.ContainsKey(color))
                {
                    dic.Add(color, new Dictionary<string, int>());
                }
                Dictionary<string, int> dic2 = dic[color];
                foreach(string cloth in clothes)
                {
                    if(!dic2.ContainsKey(cloth))
                    {
                        dic2.Add(cloth, 0);
                    }
                    dic2[cloth]++;
                }

            }

            string[] vs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string colour = vs[0];
            string clot = vs[1];

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} clothes:");
               

                foreach (var pair in item.Value)
                {
                    if (pair.Key == clot && item.Key == colour)
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value}");
                    }

                }
            }

        }
    }
}
