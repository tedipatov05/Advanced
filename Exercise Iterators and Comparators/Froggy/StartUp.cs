using System;
using System.Linq;
using System.Collections.Generic;

namespace Froggy
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
           var lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Console.WriteLine(String.Join(", ",lake));
        }
    }
}
