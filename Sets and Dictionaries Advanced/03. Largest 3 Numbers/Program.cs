using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse)
            .OrderByDescending(x => x).ToList().Take(3);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
