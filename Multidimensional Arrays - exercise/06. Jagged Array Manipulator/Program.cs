using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            }
            for(int row = 0; row < rows-1; row++)
            {
                if(matrix[row].Length == matrix[row+1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row+1] = matrix[row+1].Select(x => x * 2).ToArray();

                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }
            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] cmdArgs = command.Split(' ');
                if(cmdArgs[0] == "Add")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int column = int.Parse(cmdArgs[2]);
                    int value = int.Parse(cmdArgs[3]);
                    if(row>=0 && row<rows && column>=0 && column<matrix[row].Length)
                        matrix[row][column] += value;

                }
                else if(cmdArgs[0] =="Subtract")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int column = int.Parse(cmdArgs[2]);
                    int value = int.Parse(cmdArgs[3]);
                    if (row >= 0 && row < rows && column >= 0 && column < matrix[row].Length)
                        matrix[row][column] -= value;
                }
                command = Console.ReadLine();
            }
            foreach(int[] row in matrix)
            {
                Console.WriteLine(String.Join(' ',row));
            }
        }
       
    }
}
