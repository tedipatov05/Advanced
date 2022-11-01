using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            char[,] matrix = new char[input[0], input[1]];
            for (int i = 0; i < input[0]; i++)
            {
                char[] arr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
            int count = 0;
            for (int i = 0; i < input[0]-1; i++)
            {
                for (int j = 0; j < input[1]-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j + 1] && matrix[i, j] == matrix[i + 1, j])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
