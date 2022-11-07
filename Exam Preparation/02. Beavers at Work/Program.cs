using System;
using System.Linq;
using System.Collections.Generic;


namespace _02._Beavers_at_Work
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];
            for(int i = 0; i < n; i++)
            {
                string[] rowChars = Console.ReadLine().Split(' ').ToArray();   
                for(int j = 0; j < n; j++)
                {
                    matrix[i,j] = rowChars[j][0];
                }
            }
            (int row, int col) = FindBeaverLocation(matrix);
            while(true)
            {
                string command = Console.ReadLine();
                if(command == "end")
                {
                    break;
                }
                if(command == "up")
                {
                    Move(matrix, row, col, row - 1, col);
                }
                else if(command =="down")
                {
                    Move(matrix, row, col, row + 1, col);
                }
                else if(command=="left")
                {
                    Move(matrix, row, col, row, col-1);
                }
                else if(command == "right")
                {
                    Move(matrix, row, col, row , col+1);
                }
            }

        }

        private static void Move(char[,] matrix, int row, int col, int newRow, int newCol)
        {
            matrix[row, col] = '-';
            matrix[newRow, newCol] = 'B';

        }

        private static (int x, int y) FindBeaverLocation(char[,] matrixx)
        {
            for(int row = 0; row < matrixx.GetLength(0); row++)
            {
                for(int col = 0; col < matrixx.GetLength(1); col++)
                {
                    if(matrixx[row,col] != 'B')
                    {
                        return (row,col);
                    }
                }
            }
            throw new Exception("Beaver not found");
        }
        
    }
}
