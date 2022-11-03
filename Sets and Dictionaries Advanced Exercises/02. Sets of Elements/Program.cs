using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //n -> length of set1
            //m -> lenght of set2
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = arr[0];
            int m = arr[1];

            HashSet<int> firstSet = new HashSet<int>(); //set1\
            for(int i = 1; i <= n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> secondSet = new HashSet<int>(); //set2
            for( int i = 1; i <= m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            firstSet.IntersectWith(secondSet); // in the firstSet remains only element, which are in the secondSet
            Console.WriteLine(string.Join(" ",firstSet));
        }
    }
}
