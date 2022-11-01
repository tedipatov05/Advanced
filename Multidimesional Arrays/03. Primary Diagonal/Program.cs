using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] values = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(i == j)
                    {
                        sum+=matrix[i, j];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
