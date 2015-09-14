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
            string[] challengeWords = {"billowy", "biopsy", "chinos", "defaced", "chintz", "sponged", "bijoux", "abhors", "fiddle", "begins", "chimps", "wronged" };
            foreach (string word in challengeWords)
            {
                Console.WriteLine(Analyzer(word));
            }
            Console.Read();
        }

        public static string Analyzer(string s)
        {
            int i = 0;
            while ( i < s.Length-1)
            {
                if (s[i] <= s[i + 1])
                {
                    i++;
                    if (i == s.Length-1)
                        return (s + "  IN ORDER");
                }
                else if (s[i] >= s[i+1])
                {
                    i++;
                    if (i == s.Length-1)
                        return (s + "  REVERSE ORDER");
                }
                else
                    return (s + "  NOT IN ORDER");
            }
            return "This code isn't working";
        }
    }
}
