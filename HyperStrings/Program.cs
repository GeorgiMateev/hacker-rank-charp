using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            var n = line[0];
            var m = line[1];

            var superStrings = new string[n];

            for (int i = 0; i < n; i++)
            {
                superStrings[i] = Console.ReadLine();
            }

            var memoization = new long[m + 1];

            long result = dynamicFunction(m, superStrings, memoization);

            // for empty string
            result++;

            Console.WriteLine(result);
        }

        private static long dynamicFunction(int m, string[] superStrings, long[] memoization)
        {
            if (m <= 0)
            {
                return 0;
            }

            if (memoization[m] > 0)
            {
                return memoization[m];
            }

            long result = 0;

            for (int i = 0; i < superStrings.Length; i++)
            {
                var currentString = superStrings[i];                

                if (currentString.Length <= m)
                {
                    result++;
                    result += dynamicFunction(m - currentString.Length, superStrings, memoization);
                }
            }

            memoization[m] = result % 1000000007;
            return memoization[m];
        }
    }
}
