using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> textHistory = new Stack<string>();


            for(int i = 1; i <= n; i++)
            {
                string command = Console.ReadLine();
                if(command.StartsWith("1"))
                {
                    textHistory.Push(sb.ToString());
                    string textToAdd = command.Split(' ')[1];
                    sb.Append(textToAdd);
                   
                }
                else if(command.StartsWith("2"))
                {
                    textHistory.Push(sb.ToString());
                    int count = int.Parse(command.Split(' ')[1]);
                    sb.Remove(sb.Length-count,count);
                }
                else if( command.StartsWith("3"))
                {
                    int index = int.Parse(command.Split(' ')[1]);
                    Console.WriteLine(sb[index-1]);
                }
                else if (command.StartsWith("4"))
                {
                    sb = new StringBuilder(textHistory.Pop());
                }
            }
            
        }
    }
}
