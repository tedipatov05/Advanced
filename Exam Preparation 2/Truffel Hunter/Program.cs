using System;

namespace Truffel_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()); //размер на гората (матрицата) -> бр. редове == бр. колони
            char[,] matrix = new char[size, size]; //гора = масив от символи

            //пълнене на матрицата
            for (int row = 0; row <= size - 1; row++)
            {
                char[] currentRowElements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
                //бр. колоните = бр. елементите в currentRowElements
                //"B W S - -".Replace -> "BWS--".ToCharArray() -> ['B', 'W', 'S', '-', '-']
                for (int col = 0; col < currentRowElements.Length; col++)
                {
                    matrix[row, col] = currentRowElements[col];
                }
            }

            int countBlack = 0;
            int countWhite = 0;
            int countSummer = 0;
            int eaten = 0; //брой изядени трюфели

            //команди
            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                //1. "Collect {row} {col}".Split() -> ["Collect", "{row}", "{col}"]
                //2. "Wild_Boar {row} {col} {direction}".Split() -> ["Wild_Boar", "{row}", "{col}", "{direction}"]
                string commandName = command.Split()[0]; //"Collect" или "Wild_Boar"
                int row = int.Parse(command.Split()[1]);
                int col = int.Parse(command.Split()[2]);

                if (commandName == "Collect")
                {
                    //взема трюфел
                    char truffel = matrix[row, col]; //B, S, W
                    matrix[row, col] = '-';
                    if (truffel == 'B')
                    {
                        countBlack++;
                    }
                    else if (truffel == 'W')
                    {
                        countWhite++;
                    }
                    else if (truffel == 'S')
                    {
                        countSummer++;
                    }
                }
                else if (commandName == "Wild_Boar")
                {
                    string direction = command.Split()[3]; //"up", "down", "left" and "right"

                    switch (direction)
                    {
                        case "up":
                            //докато имаме редове нагоре
                            while (IsValidRow(row, size))
                            {
                                //проверка дали на мястото, на което отива има трюфел
                                if (EatBoar(row, col, matrix))
                                {
                                    //глиганът е изял трюфела
                                    eaten++;
                                }
                                //движи: ред -= 2; колоната не се бара
                                row -= 2;
                            }
                            break;
                        case "down":
                            //докато имаме редове надолу
                            while (IsValidRow(row, size))
                            {
                                //проверка дали на мястото, на което отива има трюфел
                                if (EatBoar(row, col, matrix))
                                {
                                    //глиганът е изял трюфела
                                    eaten++;
                                }
                                //движи: ред += 2; колоната не се бара
                                row += 2;
                            }
                            break;
                        case "left":
                            //докато имаме колони наляво
                            while (IsValidCol(col, size))
                            {
                                //проверка дали на мястото, на което отива има трюфел
                                if (EatBoar(row, col, matrix))
                                {
                                    //глиганът е изял трюфела
                                    eaten++;
                                }
                                //движи: ред не се барат; колони -= 2
                                col -= 2;
                            }
                            break;
                        case "right":
                            //докато имаме колони надясно
                            while (IsValidCol(col, size))
                            {
                                //проверка дали на мястото, на което отива има трюфел
                                if (EatBoar(row, col, matrix))
                                {
                                    //глиганът е изял трюфела
                                    eaten++;
                                }
                                //движи: ред не се барат; колони += 2
                                col += 2;
                            }
                            break;
                    }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eaten} truffles.");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        //true -> ако е изял трюфел
        //false -> ако не е изял трюфел
        private static bool EatBoar(int row, int col, char[,] matrix)
        {
            char currentSymbol = matrix[row, col];
            if (currentSymbol == 'S' || currentSymbol == 'B' || currentSymbol == 'W')
            {
                //изяжда трюфела
                matrix[row, col] = '-';
                return true;
            }
            return false;
        }

        public static bool IsValidRow(int row, int size)
        {
            return row >= 0 && row < size;
        }

        public static bool IsValidCol(int col, int size)
        {
            return col >= 0 && col < size;
        }
    }
    
}
