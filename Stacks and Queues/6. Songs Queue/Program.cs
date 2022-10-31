using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", "));
             
            while(queue.Count > 0)
            {
                string command = Console.ReadLine();
                if(command =="Play")
                {
                    queue.Dequeue();
                }
                else if(command.Contains("Add") )
                {
                    string song = command.Substring(4);
                    if(queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if(command == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
