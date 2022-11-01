using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[input[0], input[1]];
            for (int i = 0; i < input[0]; i++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
            string command = Console.ReadLine();
            while(command!="END")
            {
                if(!Validatecommand(command,rows,cols))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    string[] cmdArgs = command.Split(' ');
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);

                    string firstElement = matrix[row1, col1];
                    string secondElement = matrix[row2, col2];
                    matrix[row1, col1] = secondElement;
                    matrix[row2, col2] = firstElement;
                    PrintMatrix(matrix);
                }


                command = Console.ReadLine();
            }
            
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for(int row = 0;row < matrix.GetLength(0);row++)
            {
                for(int col = 0;col < matrix.GetLength(1);col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool Validatecommand(string command,int rows, int cols)
        {
            string[] cmdArgs = command.Split(' ');
            if(cmdArgs.Length == 5 && cmdArgs[0] == "swap")
            {
                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);   
                int col2 = int.Parse(cmdArgs[4]);

                if(row1>=0 && row1<rows && col1>=0 && col1<cols 
                    && row2>=0 && row2<rows && col2>=0 && col2<cols)
                {
                    return true;
                }
                return false;

              
            }
            return false;
        }
    }
}
