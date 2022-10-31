using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();
            int[] num = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            foreach(int n in num)
            {
                stack.Push(n);
            }
            

            for (int i = 0; i < nums[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(nums[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count() > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }



        }
    }
}
