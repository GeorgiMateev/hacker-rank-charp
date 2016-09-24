using System;
using System.Collections.Generic;
using System.Linq;

namespace SherlockAndValidStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();

            var chars = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (chars.ContainsKey(c))
                {
                    chars[c]++;
                }
                else
                {
                    chars.Add(c, 1);
                }
            }

            var frequences = new Dictionary<int, int>();
            foreach (var charCount in chars)
            {
                if (frequences.ContainsKey(charCount.Value))
                {
                    frequences[charCount.Value]++;
                }
                else
                {
                    frequences.Add(charCount.Value, 1);
                }
            }

            if (frequences.Count > 2)
            {
                Console.WriteLine("NO");
            }
            else if (frequences.Count == 1)
            {
                Console.WriteLine("YES");
            }
            else if (frequences.Count == 2 && (frequences.First().Value == 1 || frequences.Last().Value == 1))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
