using System;
using System.Text;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            

            int countOfBlack = 0;
            int countOfSummer = 0;
            int countOfWhite = 0;
            int wildBoarEaten = 0;

            char[,] forest = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] rowChars = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < n; j++)
                {
                    forest[i, j] = rowChars[j][0];
                }
            }

            string command = Console.ReadLine();
            while(command != "Stop the hunt")
            {
                string[] cmdArgs = command.Split(' ');
                string type = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);    
                int col = int.Parse(cmdArgs[2]);
                if (IsInForest(row, col, forest))
                { 
                    if (type == "Collect")
                    {
                        if (forest[row, col] == 'B')
                        {
                            countOfBlack++;
                            forest[row, col] = '-';
                        }
                        else if(forest[row, col] == 'S')
                        {
                            countOfSummer++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'W')
                        {
                            countOfWhite++;
                            forest[row, col] = '-';
                        }
                        
                    }
                    else if(type == "Wild_Boar")
                    {
                        string direction = cmdArgs[3];
                        while (IsInForest(row, col, forest))
                        {
                            if (direction == "down")
                            {
                                if (forest[row, col] == 'W')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;
                                    
                                }
                                else if(forest[row, col] == 'S')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;
                                    
                                }
                                else if (forest[row,col] == 'B')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;
                                    
                                }
                               
                                row += 2;
                                
                            }
                            else if(direction == "up") 
                            {
                                if (forest[row, col] == 'W')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;
                                  
                                }
                                else if (forest[row, col] == 'S')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;
                                    
                                }
                                else if (forest[row, col] == 'B')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;
                                   
                                }
                                row -= 2;
                                
                            }
                            else if(direction == "right")
                            {
                                if (forest[row, col] == 'W')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;

                                }
                                else if (forest[row, col] == 'S')
                                {
                                    forest[row, col] = '-';
                                    wildBoarEaten++;

                                }
                                else if (forest[row, col] == 'B')
                                {
                                    
                                    forest[row, col] = '-';
                                    wildBoarEaten++;

                                }
                                col += 2;
                            }
                            else if(direction == "left")
                            {
                                if (forest[row, col] == 'W')
                                {
                                    
                                    forest[row, col] = '-';
                                    wildBoarEaten++;

                                }
                                else if (forest[row, col] == 'S')
                                {
                                    
                                    forest[row, col] = '-';
                                    wildBoarEaten++;

                                }
                                else if (forest[row, col] == 'B')
                                {
                                    
                                    forest[row, col] = '-';
                                    wildBoarEaten++;

                                }
                                col -= 2;
                            }
                        }
                    }
                    command = Console.ReadLine();
                    


                }
               

            }
            Console.WriteLine($"Peter manages to harvest {countOfBlack} black, {countOfSummer} summer, and {countOfWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarEaten} truffles.");
            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    Console.Write(forest[row, col] + " ");
                }
                Console.WriteLine();
            } 
        }
        private static bool IsInForest(int row, int col, char[,] forest)
        {
            return row >= 0 && row < forest.GetLength(0) && 
                col >= 0 && col < forest.GetLength(1);
        }
       
    }
}
