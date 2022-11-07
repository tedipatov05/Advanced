using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] num = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int count = num.Length;
            int sum = num.Sum();
            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
    }
}
