using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };

            Queue<string> keysQueue = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<int> valuesStack = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int startMealsCount = keysQueue.Count;

            while ((keysQueue.Count > 0) && (valuesStack.Count > 0))
            {
                int currentCallories = valuesStack.Pop();

                int currentMealCallories = mealsCalories[keysQueue.Peek()];

                if (currentCallories - currentMealCallories >= 0)
                {
                    currentCallories -= currentMealCallories;
                    keysQueue.Dequeue();
                    valuesStack.Push(currentCallories);
                }
                else if (valuesStack.Count > 0)
                {
                    currentCallories -= currentMealCallories;
                    currentCallories += valuesStack.Pop();
                    if (currentCallories > 0)
                    {
                        valuesStack.Push(currentCallories);
                        keysQueue.Dequeue();
                    }

                    if (valuesStack.Count == 0)
                    {
                        keysQueue.Dequeue();
                    }
                }
                else
                {
                    if (valuesStack.Count == 0)
                    {
                        keysQueue.Dequeue();
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            if (valuesStack.Count > 0)
            {
                sb.AppendLine($"John had {startMealsCount} meals.");
                sb.AppendLine($"For the next few days, he can eat {string.Join(", ", valuesStack)} calories.");
            }
            else
            {
                sb.AppendLine($"John ate enough, he had {startMealsCount - keysQueue.Count} meals.");
                sb.AppendLine($"Meals left: {string.Join(", ", keysQueue)}.");

            }

            Console.WriteLine(sb.ToString().TrimEnd());

        }
    }
}
