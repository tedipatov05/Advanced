using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for(int i = 0; i < n; i++)
            {
                string[] vs = Console.ReadLine().Split(' ');
                foreach(string v in vs)
                {
                    set.Add(v);
                }
               
            }
            Console.WriteLine(string.Join(" ",set.OrderBy(x => x )));
        }
    }
}
