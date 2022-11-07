using System;
using System.Linq;

namespace Stack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            while(true)
            {
                var tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "END") break;
                if(tokens[0] == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(a => a.Split(",").First()).ToArray());
                }
                else if(tokens[0] =="Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            foreach(var el in stack)
            {
                Console.WriteLine(el);
            }
            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }
        }
    }
}
