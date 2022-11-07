using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> predicate = num => num % n == 0;

            numbers.RemoveAll(predicate);
            Console.WriteLine(String.Join(" ",numbers));

        }
    }
}
