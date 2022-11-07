using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x*1.2)
                .ToArray();
            foreach(double num in nums)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
