using System;
using System.Linq;

namespace _02._Sum_Matrix_Colums
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
            for(int i = 0; i < rowsCount; i++)
            {
                int[] values = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
                for(int j = 0; j < colsCount; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            for(int i = 0; i < colsCount; i++)
            {
                int sum = 0;
                for(int j = 0; j < rowsCount; j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
