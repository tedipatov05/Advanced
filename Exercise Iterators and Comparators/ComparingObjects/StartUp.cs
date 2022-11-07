using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while(true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "END") break;

                string personName = tokens[0];
                int personAge = int.Parse(tokens[1]);
                string personTown = tokens[2];

                Person person = new Person(personName, personAge, personTown);
                people.Add(person);

            }
            var index = int.Parse(Console.ReadLine()) -1;
            int equal = 0;
            int notEqual = 0;
             

            foreach(Person person in people)
            {
                if(people[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            if(equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {people.Count}");
            }
        }
    }
}
