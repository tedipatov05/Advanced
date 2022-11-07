using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();
            var lines = int.Parse(Console.ReadLine());

            for(int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));
                sortedSet.Add(person);
                hashSet.Add(person);

            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
