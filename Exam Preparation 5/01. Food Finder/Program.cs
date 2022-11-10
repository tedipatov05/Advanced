using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));

            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            string pear1 = "pear";
            string flour1 = "flour";
            string pork1 = "pork";
            string olive1 = "olive";

            int pearCount = pear.Count();
            int flourCount = flour.Count();
            int porkCount = pork.Count();
            int oliveCount = olive.Count();

            int vowelsCount = 0;
            int startVowelsCount = vowels.Count;


            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                if (vowelsCount < startVowelsCount)
                {
                    if (pear.Contains(currentVowel) && pearCount > 0)
                    {
                        pear = pear.Replace(currentVowel.ToString(), "");
                        pearCount--;

                    }
                    if (flour.Contains(currentVowel) && flourCount > 0)
                    {
                        flour = flour.Replace(currentVowel.ToString(), "");
                        flourCount--;

                    }
                    if (pork.Contains(currentVowel) && porkCount > 0)
                    {
                        pork = pork.Replace(currentVowel.ToString(), "");
                        porkCount--;

                    }
                    if (olive.Contains(currentVowel) && oliveCount > 0)
                    {
                        olive = olive.Replace(currentVowel.ToString(), "");
                        oliveCount--;

                    }
                    vowelsCount++;
                }


                if (pear.Contains(currentConsonant))
                {
                    pear = pear.Replace(currentConsonant.ToString(), "");
                    pearCount--;
                }
                if (flour.Contains(currentConsonant))
                {
                    flour = flour.Replace(currentConsonant.ToString(), "");
                    flourCount--;
                }
                if (pork.Contains(currentConsonant))
                {
                    pork = pork.Replace(currentConsonant.ToString(), "");
                    porkCount--;
                }
                if (olive.Contains(currentConsonant))
                {
                    olive = olive.Replace(currentConsonant.ToString(), "");
                    oliveCount--;
                }

                vowels.Enqueue(currentVowel);
            }

            List<string> wordsFound = new List<string>();

            if (pear.Length == 0)
            {
                wordsFound.Add(pear1);
            }
            if (flour.Length == 0)
            {
                wordsFound.Add(flour1);
            }
            if (pork.Length == 0)
            {
                wordsFound.Add(pork1);
            }
            if (olive.Length == 0)
            {
                wordsFound.Add(olive1);
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            foreach (var word in wordsFound)
            {
                Console.WriteLine(word);
            }
        }
    }
}
