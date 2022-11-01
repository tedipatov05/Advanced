using System;
using System.Linq;

namespace _05._Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);
            int[,] matrix = new int[rowsCount, colsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                int[] values = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
                for (int j = 0; j < colsCount; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            long maxSum = long.MinValue;
            int bestCol = 0;
            int bestRow = 0;
            for(int row =0; row < rowsCount-1; row++)
            {
                for(int col =0; col < colsCount-1; col++)
                {
                    long sum = matrix[row, col] + matrix[row + 1, col]
                        + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        bestCol = col;
                        bestRow = row;
                        
                    }
                }
            }
            Console.WriteLine(matrix[bestRow,bestCol] + " " + matrix[bestRow, bestCol+1]);
            Console.WriteLine(matrix[bestRow+1 , bestCol] + " " + matrix[bestRow+1, bestCol+1]);

            Console.WriteLine(maxSum);
            
        }
    }
}
