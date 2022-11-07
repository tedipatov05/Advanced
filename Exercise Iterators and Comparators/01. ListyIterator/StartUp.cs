﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> listy = null;
            while(command != "END")
            {
                string[] tokens = command.Split(' ');
                if (tokens[0]=="Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0]=="Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (tokens[0]=="Print")
                {
                    listy.Print();
                }
                else if(tokens[0]=="HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }


                command = Console.ReadLine();
            }
        }
    }
}
