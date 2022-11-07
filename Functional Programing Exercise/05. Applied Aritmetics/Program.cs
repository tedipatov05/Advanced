using System;
using System.Linq;
using System.Collections.Generic;


namespace _05._Applied_Aritmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> add = list => list.Select(num => num+=1).ToList();

            Func<List<int>, List<int>> multiply = list => list.Select(num => num *= 2).ToList();

            Func<List<int>, List<int>> subtract = list => list.Select(num => num -= 1).ToList();

            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));

            string command = Console.ReadLine();

            while(command != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = add(nums); 
                        break;
                    case "multiply":
                        nums = multiply(nums);
                        break;
                    case "subtract":
                        nums = subtract(nums);
                        break;
                    case "print":
                        print(nums);
                        break;
                    
                }
                command = Console.ReadLine();

            }
        }
    }
}
