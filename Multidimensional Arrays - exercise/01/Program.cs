using System;
using System.Linq;   

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int col = 0; col < n; col++)
            {
                matrix[col] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            long primaryDiagonal = 0;
            for (int col = 0; col < n; col++)
            {
                primaryDiagonal += matrix[col][col];
            }
            long secondaryDiagonal = 0;
            int col1 = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                secondaryDiagonal += matrix[col1][i];
                col1++;
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
