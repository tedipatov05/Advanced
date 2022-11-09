using System;
using System.Linq;
using System.Collections.Generic;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //"40 50 70 120 10 20".Split
            //["40", "50", "70", "120", "10", "20"].Select(int.Parse)
            //[40, 50, 70, 120, 10, 20]

            int[] carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //стомана -> първия към последния елемент
            Queue<int> queueSteel = new Queue<int>(steel);

            //въглерод -> последния към първия елемент
            Stack<int> stackCarbon = new Stack<int>(carbon);

            //запис: име на меч -> брой на мечовете от този вид
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>
            {
                {"Broadsword", 0},
                { "Sabre", 0},
                { "Katana", 0},
                { "Shamshir", 0},
                { "Gladius", 0}
            };


            //стоп: ако свърши или стоманата или въглерода
            //продължаваме: имаме и стоамана и въглерод
            //1. взимам стомана(peek) и въглерод(peek)
            //2. сума = стомана + въглерод
            //3. проверка дали сумата може да изработваме меч
            //3.1. премахвам стоманата и въглерода
            //3.2. премахваме стоманата, увеличаваме въглерода с 5

            int totalSwords = 0; //общия брой изковани мечове
            while (queueSteel.Count > 0 && stackCarbon.Count > 0)
            {
                int currentSteel = queueSteel.Peek();
                int currentCarbon = stackCarbon.Peek();
                int sum = currentSteel + currentCarbon;

                if (sum == 70)
                {
                    //изработваме меч Gladius
                    swords["Gladius"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 80)
                {
                    //изработваме меч Shamshir
                    swords["Shamshir"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 90)
                {
                    //изработваме меч Katana
                    swords["Katana"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 110)
                {
                    //изработваме меч Sabre
                    swords["Sabre"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 150)
                {
                    //изработваме меч Broadsword
                    swords["Broadsword"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else
                {
                    //не изработваме меч
                    queueSteel.Dequeue();
                    currentCarbon += 5;
                    stackCarbon.Pop();
                    stackCarbon.Push(currentCarbon);
                }
            }

            //свършат или въглерода или стоманата
            if (totalSwords >= 1)
            {
                Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            //печатаме стоманата
            if (queueSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine("Steel left: " + string.Join(", ", queueSteel));
            }

            //печатаме въглерода
            if (stackCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine("Carbon left: " + string.Join(", ", stackCarbon));
            }

            //мечове
            foreach (var swordItem in swords.OrderBy(pair => pair.Key))
            {
                //swordItem -> key:име на меча, value: бр. мечове
                if (swordItem.Value > 0)
                {
                    Console.WriteLine($"{swordItem.Key}: {swordItem.Value}");
                }
            }
        }
    }
}
