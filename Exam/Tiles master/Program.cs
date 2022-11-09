using System;
using System.Linq;
using System.Collections.Generic;

namespace Tiles_master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] greyTiles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> grey = new Queue<int>(greyTiles);
            Stack<int> white = new Stack<int>(whiteTiles);

            Dictionary<string, int> newTiles = new Dictionary<string, int>
            {
                {"Sink",0 },
                {"Oven", 0 },
                { "Countertop", 0},
                { "Wall" , 0},
                {"Floor",0 }


            };
            int sinkArea = 40;
            int ovenArea = 50;
            int CountertopArea = 60;
            int wallArea = 70;


            while (grey.Any() && white.Any())
            {
                int currentWhite = white.Peek();
                int currentGrey = grey.Peek();
                if(currentWhite != currentGrey)
                {
                    white.Pop();
                    currentWhite /= 2;
                    grey.Dequeue(); 
                    white.Push(currentWhite);
                    grey.Enqueue(currentGrey);
                }
                else
                {
                    int newTile = currentGrey + currentWhite;        
                    if(newTile == sinkArea)
                    {
                        newTiles["Sink"]++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else if(newTile == wallArea)
                    {
                        newTiles["Wall"]++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else if(newTile == ovenArea)
                    {
                        newTiles["Oven"]++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else if(newTile==CountertopArea)
                    {
                        newTiles["Countertop"]++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else
                    {
                        newTiles["Floor"]++;
                        white.Pop();
                        grey.Dequeue();
                    }
                }
                
            }
            if (white.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (grey.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            newTiles = newTiles.Where(t => t.Value>0).ToDictionary(t =>t.Key, t => t.Value);
            foreach(var item in newTiles.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            

        }
    }
}
