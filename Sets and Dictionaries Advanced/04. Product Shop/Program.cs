using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var dict = new Dictionary<string, Dictionary<string, double>>();
            while(command != "Revision")
            {
                string[] cmdArgs = command.Split(", ");
                string shop = cmdArgs[0];
                string product = cmdArgs[1];
                double price = double.Parse(cmdArgs[2]);
                if(!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string, double>());
                }
                dict[shop][product] = price;



                command = Console.ReadLine();
            }

            foreach(var shop in dict.OrderBy(sp => sp.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                var productsAndPrices = shop.Value;
                foreach(var product in productsAndPrices)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
