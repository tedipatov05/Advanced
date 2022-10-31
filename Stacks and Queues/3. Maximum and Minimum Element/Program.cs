﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                if(nums[0] == 1)
                {
                    stack.Push(nums[1]);
                }
                else if(nums[0] == 2 && stack.Count>0)
                {
                    stack.Pop();
                }
                else if(nums[0] == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if(nums[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }

            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
