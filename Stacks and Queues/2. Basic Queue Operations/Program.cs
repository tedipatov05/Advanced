using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach(int n in nums)
            {
                queue.Enqueue(n);
            }
            for(int n = 0; n < num[1]; n++)
            {
                queue.Dequeue();
            }
            if(queue.Contains(num[2]))
            {
                Console.WriteLine("true");
            }
            else if(queue.Count() > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
