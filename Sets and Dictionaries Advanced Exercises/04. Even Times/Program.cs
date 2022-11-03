using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int,int> dict = new Dictionary<int,int>();
            for(int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if(!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }
                dict[num]++;
            }
            var arr = dict.Where(x => x.Value%2==0).ToDictionary(x => x.Key, x =>x.Value);
            foreach(var x in arr)
            {
                Console.WriteLine(x.Key);
            }
        }
    }
}
