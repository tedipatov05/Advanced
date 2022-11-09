using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] queue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] stack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> guests = new Queue<int>(queue);
            Stack<int> plates = new Stack<int>(stack);

            int wastedFood = 0;
            bool allGuestsAreFed = false;
            bool noMorePlates = false;

            List<int> claimed = new List<int>();

            while (true)
            {
                int guestValue = guests.Peek();
                int plateValue = plates.Peek();

                if (guestValue > plateValue)
                {
                    guests.Dequeue();
                    plates.Pop();

                    // When a guest's integer value reaches 0 or less, it gets removed.
                    // It is possible that the current guest's value is greater than the current food's value.
                    // In that case you pick plates until you reduce the guest's integer value to 0 or less.
                    guests = new Queue<int>(guests.Reverse());
                    guests.Enqueue(guestValue - plateValue);
                    guests = new Queue<int>(guests.Reverse());
                }
                else if (guestValue < plateValue)
                {
                    // If a plate's value is greater or equal to the guest's current value,
                    // you fill up the guest and the remaining food becomes wasted.
                    plates.Pop();
                    guests.Dequeue();
                    wastedFood += plateValue - guestValue;
                }
                else
                {
                    plates.Pop();
                    guests.Dequeue();
                }

                if (guests.Count == 0)
                {
                    allGuestsAreFed = true;
                    break;
                }

                if (plates.Count == 0)
                {
                    noMorePlates = true;
                    break;
                }
            }

            if (allGuestsAreFed)
            {
                // If you have managed to fill up all of the guests,
                // print the remaining prepared plates of food, from the last entered – to the first,
                string result = string.Join(" ", plates.Reverse().ToList());
                Console.WriteLine($"Plates: {result}");
            }
            else if (noMorePlates)
            {
                // otherwise you must print the remaining guests,
                // by order of entrance – from the first entered – to the last. 
                string result = string.Join(" ", guests.ToList());
                Console.WriteLine($"Guests: {result}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
