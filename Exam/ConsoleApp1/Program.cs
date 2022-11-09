using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static int Vancol;
        private static int Vanrow;
        private static int totalHoles = 1;
        private static char[,] wall;
        private static int countOfRods;
        private static int totaldirects; 
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            wall = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] matrix = Console.ReadLine().Replace(" ", "")

                    .ToCharArray();
                for (int col = 0; col < matrix.Length; col++)
                {
                    wall[row, col] = matrix[col];
                    if (wall[row, col] == 'V')
                    {
                        Vancol = col;
                        Vanrow = row;
                    }
                }
            }
            List<string> directions = new List<string>();

            string direction = Console.ReadLine();
            while (direction != "End")
            {
                directions.Add(direction);
               

                
            
                if (direction == "up")
                {
                    if (!IsInside(Vanrow - 1, Vancol))
                    {
                        direction = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Move(-1, 0);
                        if (wall[Vanrow, Vancol] == 'C')
                        {
                            Console.WriteLine($"Vanko got electrocuted, but he managed {totalHoles} hole(s).");
                            directions.Add(direction);
                            break;
                        }
                    }
                }
                else if (direction == "down")
                {
                    if (!IsInside(Vanrow + 1, Vancol))
                    {
                        direction = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Move(1, 0);
                        if (wall[Vanrow, Vancol] == 'C')
                        {
                            Console.WriteLine($"Vanko got electrocuted, but he managed {totalHoles} hole(s).");
                            directions.Add(direction);
                            break;
                        }
                    }
                }
                else if (direction == "left")
                {
                    if (!IsInside(Vanrow, Vancol - 1))
                    {
                        direction = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Move(0, -1);
                        if (wall[Vanrow, Vancol] == 'C')
                        {
                            Console.WriteLine($"Vanko got electrocuted, but he managed {totalHoles} hole(s).");
                            directions.Add(direction);
                            break;
                        }
                    }
                }
                else if (direction == "right")
                {
                    if (!IsInside(Vanrow, Vancol + 1))
                    {
                        direction = Console.ReadLine();
                        continue;
                        
                    }
                    else
                    {
                        Move(0, 1);
                        if (wall[Vanrow, Vancol] == 'C')
                        {
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {totalHoles} hole(s).");
                            directions.Add(direction);
                            break;
                        }
                    }
                    
                }
                totaldirects++;

                direction = Console.ReadLine();


            }
            if(directions.Count <= totaldirects+1 )   
                Console.WriteLine($"Vanko managed to make {totalHoles} hole(s) and he hit only {countOfRods} rod(s).");
            for (int i = 0; i < wall.GetLength(0); i++)
            {

                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    Console.Write(wall[i, j]);

                }
                Console.WriteLine();
            }
        }
        static void Move(int row, int col)
        {
            int prevRow = Vanrow;
            int prevCol = Vancol;
            wall[Vanrow, Vancol] = '*';
            Vanrow += row;
            Vancol += col;


            if (wall[Vanrow, Vancol] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                countOfRods++;
                Vancol = prevCol;
                Vanrow = prevRow;

            }
            else if (wall[Vanrow, Vancol] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{Vanrow}, {Vancol}]!");
                 
            }
            
            else if (wall[Vanrow, Vancol] == '-')
            {
                totalHoles++;
            }
            wall[Vanrow, Vancol] = 'V';

        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < wall.GetLength(0) &&
                   col >= 0 && col < wall.GetLength(1);
        }
    }
}
