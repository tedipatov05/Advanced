using System;
using System.Linq;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            if (numberOfRows == 0)
            {
                return;
            }

            int cols = numberOfRows;
            //char[,] matrix = new char[numberOfRows, cols];

            // Field is rectangular !!!
            char[][] matrix = new char[numberOfRows][];
            int armyRow = -1;
            int armyCol = -1;

            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                char[] currentSymbols = Console.ReadLine().ToCharArray();
                //matrix[rowIndex] = new char[currentSymbols.Length];
                matrix[rowIndex] = currentSymbols;
                for (int colIndex = 0; colIndex < currentSymbols.Length; colIndex++)
                {
                    //matrix[rowIndex][colIndex] = currentSymbols[colIndex];
                    if (matrix[rowIndex][colIndex] == 'A')
                    {
                        armyRow = rowIndex;
                        armyCol = colIndex;
                    }
                }
            }

            matrix[armyRow][armyCol] = '-';
            bool gameOver = false;

            if (armyArmor <= 0)
            {
                matrix[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                gameOver = true;
            }

            while (gameOver == false)
            {
                string[] cmdArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = cmdArr[0].ToLower();
                int givenRow = int.Parse(cmdArr[1]);
                int givenCol = int.Parse(cmdArr[2]);
                matrix[givenRow][givenCol] = 'O';
                armyArmor -= 1;

                MoveArmy(direction, matrix, ref armyRow, ref armyCol, ref armyArmor, ref gameOver);
            }

            if (gameOver)
            {
                PrintMatrix(matrix);
            }
        }

        public static void MoveArmy(string direction, char[][] matrix, ref int armyRow, ref int armyCol, ref int armyArmor,
            ref bool gameOver)
        {
            switch (direction)
            {
                case "up":
                    bool isInside = isValid(matrix, armyRow - 1, armyCol);
                    if (isInside)
                    {
                        armyRow -= 1;
                        //armyArmor -= 1;
                        CheckField(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }
                    else
                    {
                        Outside(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }

                    break;
                case "down":
                    isInside = isValid(matrix, armyRow + 1, armyCol);
                    if (isInside)
                    {
                        armyRow += 1;
                        //armyArmor -= 1;
                        CheckField(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }
                    else
                    {
                        Outside(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }

                    break;
                case "left":
                    isInside = isValid(matrix, armyRow, armyCol - 1);
                    if (isInside)
                    {
                        armyCol -= 1;
                        //armyArmor -= 1;
                        CheckField(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }
                    else
                    {
                        Outside(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }

                    break;
                case "right":
                    isInside = isValid(matrix, armyRow, armyCol + 1);
                    if (isInside)
                    {
                        armyCol += 1;
                        //armyArmor -= 1;
                        CheckField(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }
                    else
                    {
                        Outside(matrix, armyRow, armyCol, ref armyArmor, ref gameOver);
                    }

                    break;
                default: break;
            }
        }

        private static void Outside(char[][] matrix, int armyRow, int armyCol, ref int armyArmor, ref bool gameOver)
        {
            //armyArmor -= 1;
            if (armyArmor <= 0)
            {
                matrix[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                gameOver = true;
            }
        }

        private static void CheckField(char[][] matrix, int armyRow, int armyCol, ref int armyArmor, ref bool gameOver)
        {
            // Validation required otherwise 90/100
            if (armyArmor <= 0 && matrix[armyRow][armyCol] != 'M')
            {
                matrix[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                gameOver = true;
                return;
            }


            if (matrix[armyRow][armyCol] == 'O')
            {
                armyArmor -= 2;
                if (armyArmor <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    gameOver = true;
                }
                else
                {
                    matrix[armyRow][armyCol] = '-';
                }
            }
            else if (matrix[armyRow][armyCol] == 'M')
            {
                matrix[armyRow][armyCol] = '-';
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                gameOver = true;
            }
        }

        public static bool isValid(char[][] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0))
                && (col >= 0 && col < matrix[row].Length);
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
