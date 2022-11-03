using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] word = Console.ReadLine().ToCharArray();
            var symbols = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (!symbols.ContainsKey(c))
                {
                    symbols.Add(c, 0);
                }
                symbols[c]++;
            }
            var list  = symbols.Keys.ToList();
            list.Sort();
            foreach (var c in list)
            {
                Console.WriteLine($"{c}: {symbols[c]} time/s");
            }
        }
    }
}
