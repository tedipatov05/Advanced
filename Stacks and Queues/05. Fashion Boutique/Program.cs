using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] quantityOfClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> clothesStack = new Stack<int>(quantityOfClothes);

            int countRack = 1;
            int sumClothes = 0;

           

            while (clothesStack.Count > 0)
            {
                var currElement = clothesStack.Pop(); //взимаш стойността на последния елемент
                if (sumClothes + currElement <= capacityOfRack)     //проверяваш дали няма да се препълни ако я добавиш 
                {
                    sumClothes += currElement;                  //добавяш към сумата
                }
                else
                {
                    sumClothes = currElement;       //новата сума за новия рафт трябва да е равна на елемента, който добавяме като първи на рафта
                    countRack++;
                }
            }

            
            Console.WriteLine(countRack);
        }



    }
    
}
