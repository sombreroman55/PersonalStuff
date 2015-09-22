using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge228
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string[] challengeWords = { "billowy", "biopsy", "chinos", "defaced", "chintz", "sponged", "bijoux", "abhors", "fiddle", "begins", "chimps", "wronged" };
            foreach (string word in challengeWords)
            {
                Console.WriteLine(CharToInt(word));
            }
            Console.Read();
        }

        public static int[] CharToInt(string s)
        {
            int[] charValues = new int[s.Length];
            for (int charIndex = 0; charIndex < s.Length; charIndex++)
            {
                charValues[charIndex] = (int)s[charIndex];
            }
            return charValues;
        }

        //public static string Analyzer(string s)
        //{
        //    CharToInt(s);

        //}


    }
}