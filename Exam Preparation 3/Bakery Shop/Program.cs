using System;
using System.Linq;
using System.Collections.Generic;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] water = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] flour = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Queue<double> waterQueue = new Queue<double>(water);
            Stack<double> flourStack = new Stack<double>(flour);

            var bakeryResult = new Dictionary<string, int>
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };
            while(waterQueue.Any() && flourStack.Any())
            {
                var currentFlour = flourStack.Peek();
                var currentWater = waterQueue.Peek();   
                if(CrossantMix(currentFlour, currentWater))
                {
                    bakeryResult["Croissant"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else if(MuffinMix(currentFlour, currentWater))
                {
                    bakeryResult["Muffin"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else if(BaguetteMix(currentFlour, currentWater))
                {
                    bakeryResult["Baguette"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else if(BagelMix(currentFlour, currentWater))
                {
                    bakeryResult["Bagel"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else
                {
                    var currentFlourr = flourStack.Pop();
                    var currWater = waterQueue.Dequeue();
                    var reducedFlour = currentFlour - currWater;
                    bakeryResult["Croissant"]++;
                    flourStack.Push(reducedFlour);

                }
                
            }
            foreach (var item in bakeryResult.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            var flourLeft = flourStack.Count == 0 ? "None" : string.Join(", ", flourStack);
            var waterLeft = waterQueue.Count == 0 ? "None" : string.Join(", ", waterQueue);

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");

        }
        public static double[] ClaculatePercentage(double flour, double water)
        {
            var returnResult = new double[2];
            double result = flour + water;  
            returnResult[0] = (flour/result)*100;
            returnResult[1] = (water/result)*100;
            return returnResult;
        }
        public static bool CrossantMix(double flour ,double water)
        {
            var persentage = ClaculatePercentage(flour, water);
            if (persentage[0] == 50 && persentage[1] == 50)
            {
                return true;
            }
            return false;
        }
        public static bool MuffinMix(double flour, double water)
        {
            var persentage = ClaculatePercentage(flour, water);
            if(persentage[0] == 60 && persentage[1] == 40)
            {
                return true;
            }
            return false;
        }
        public static  bool BaguetteMix(double flour, double water)
        {
            var persentage = ClaculatePercentage(flour, water);
            if(persentage[0] == 70 && persentage[1] == 30)
            {
                return true;
            }
            return false;
        }
        public static bool BagelMix(double flour, double water)
        {
            var persentage = ClaculatePercentage(flour, water);
            if(persentage[0] == 80 && persentage[1] == 20)
            {
                return true;

            }
            return false;
        }
    }
}
