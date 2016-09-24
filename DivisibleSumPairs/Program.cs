using System;
using System.Linq;

namespace DivisibleSumPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray()[1];
            var l = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            var count = 0;
            for (int i = 0; i < l.Length - 1; i++)
            {
                for (int j = i + 1; j < l.Length; j++)
                {
                    if ((l[i] + l[j]) % k == 0)
                        count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
