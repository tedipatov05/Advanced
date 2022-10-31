using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();
            int biggestOrder = orders.Max();
            foreach(int order in orders)
            {
                queue.Enqueue(order);
            }

            while (queue.Count>0 && quantity>=queue.Peek())
            {
                quantity -= queue.Peek();
                queue.Dequeue();
            
            }

            Console.WriteLine(biggestOrder);

            if(queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
            }
        }
    }
}
