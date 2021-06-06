using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(Directory.GetCurrentDirectory().ToString().Replace(@"bin\Debug", @"\WordsData.txt"));
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Text file is empty");
            }

            Console.WriteLine("Enter the first word to find the distance");
            string Word1 = Console.ReadLine();
            if (string.IsNullOrEmpty(Word1))
            {
                Console.WriteLine("First word is empty");
            }

            Console.WriteLine("Enter the second word to find the distance");
            string Word2 = Console.ReadLine();
            if (string.IsNullOrEmpty(Word2))
            {
                Console.WriteLine("Second word is empty");
            }

            text = text.Replace(Environment.NewLine, " ").Replace("  ", " ").Replace(",", "").Replace(".", " ").ToString();
            List<string> words = text.Split(' ').ToList();
            int len = words.Count();
            int i = 0;
            int j = 0;
            int lowestDistance = -1;

            while (words.IndexOf(Word1, i + 1) >= 0)
            {
                i = words.IndexOf(Word1, i + 1);
                j = 0;
                while (words.IndexOf(Word2, j + 1) >= 0)
                {
                    j = words.IndexOf(Word2, j + 1);
                    if (lowestDistance == -1 || lowestDistance > Math.Abs(i - j))
                    {
                        lowestDistance = Math.Abs(i - j);
                        if (lowestDistance == 1)
                        {
                            break;
                        }
                    }                    
                }
                if (lowestDistance == 1)
                {
                    break;
                }
            }

            if (lowestDistance == -1)
            {
                Console.WriteLine("The distance between {0} and {1} not found", Word1, Word2);
            }
            else
            {
                Console.WriteLine("The distance between {0} and {1} is {2}", Word1, Word2, lowestDistance.ToString());
            }
            Console.Read();
        }
    }

}
