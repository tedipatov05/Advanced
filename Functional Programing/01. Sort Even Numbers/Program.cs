using System;
using System.Linq;
using System.Collections.Generic;


namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] num = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();
            string output = string.Join(", ", num);
            Console.WriteLine(output);
            
           
        }
    }
}
