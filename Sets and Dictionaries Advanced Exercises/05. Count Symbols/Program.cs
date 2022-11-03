using System;
using System

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            var symbols = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (!symbols.ContainsKey(c))
                {
                    symbols.Add(c, 0);
                }
                symbols[c]++;
            }
            foreach (var c in symbols.OrderBy(s => s))
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
