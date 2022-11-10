using System;
using System.Linq;
using System.Text;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int whiteCurrRow = 0;
            int whiteCurrCol = 0;

            int blackCurrRow = 0;
            int blackCurrCol = 0;

            char[,] matrix = new char[8, 8];
            for (int i = 0; i < 8; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] += input[j];

                    if (input[j] == 'w')
                    {
                        whiteCurrRow = i;
                        whiteCurrCol = j;
                    }
                    if (input[j] == 'b')
                    {
                        blackCurrRow = i;
                        blackCurrCol = j;
                    }
                }
            }

            while (true)
            {
                if (IsInMatrix(whiteCurrRow - 1, whiteCurrCol - 1) && matrix[whiteCurrRow - 1, whiteCurrCol - 1] == 'b')
                {
                    string position = SetPosition(whiteCurrRow - 1, whiteCurrCol - 1);
                    Console.WriteLine($"Game over! White capture on {position}.");
                    break;

                }
                else if (IsInMatrix(whiteCurrRow - 1, whiteCurrCol + 1) && matrix[whiteCurrRow - 1, whiteCurrCol + 1] == 'b')
                {
                    string position = SetPosition(whiteCurrRow - 1, whiteCurrCol + 1);
                    Console.WriteLine($"Game over! White capture on {position}.");
                    break;
                }
                else
                {
                    matrix[whiteCurrRow, whiteCurrCol] = '-';
                    whiteCurrRow -= 1;
                    matrix[whiteCurrRow, whiteCurrCol] = 'w';
                    if (whiteCurrRow == 0)
                    {
                        string position = SetPosition(whiteCurrRow, whiteCurrCol);
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {position}.");
                        break;
                    }
                }

                if (IsInMatrix(blackCurrRow + 1, blackCurrCol - 1) && matrix[blackCurrRow + 1, blackCurrCol - 1] == 'w')
                {
                    string position = SetPosition(blackCurrRow + 1, blackCurrCol - 1);
                    Console.WriteLine($"Game over! Black capture on {position}.");
                    break;
                }
                else if (IsInMatrix(blackCurrRow + 1, blackCurrCol + 1) && matrix[blackCurrRow + 1, blackCurrCol + 1] == 'w')
                {
                    string position = SetPosition(blackCurrRow + 1, blackCurrCol + 1);
                    Console.WriteLine($"Game over! Black capture on {position}.");
                    break;
                }
                else
                {
                    matrix[blackCurrRow, blackCurrCol] = '-';
                    blackCurrRow += 1;
                    matrix[blackCurrRow, blackCurrCol] = 'b';
                    if (blackCurrRow == 7)
                    {
                        string position = SetPosition(blackCurrRow, blackCurrCol);
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {position}.");
                        break;
                    }
                }
            }

        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row <= 7 && col >= 0 && col <= 7;
        }

        private static string SetPosition(int row, int col)
        {

            var sb = new StringBuilder();

            for (int i = 8; i >= 0; i--)
            {
                if (col == i)
                {
                    sb.Append((char)(i + 97));
                }
            }

            int counter = 8;
            for (int i = 0; i < 8; i++)
            {
                if (row == i)
                {
                    sb.Append(counter);
                }
                counter--;
            }
            return $"{sb}";
        }
    }
}
