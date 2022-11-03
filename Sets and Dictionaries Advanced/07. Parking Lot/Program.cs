using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> set = new HashSet<string>();
            while(input != "END")
            {
                string[] inpArgs = input.Split(", ");
                string command = inpArgs[0];
                string regrNum = inpArgs[1];
                if(command == "IN")
                {
                    set.Add(regrNum);
                }
                else if(command == "OUT" && set.Contains(regrNum))
                {
                    set.Remove(regrNum);
                }


                input = Console.ReadLine();
            }
            if(set.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, set));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
