using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoinChangeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().Select(x => int.Parse(x));
            var n = line.First();
            var m = line.Last();

            var coins = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            var matrix = new long[n + 1, m + 1];

            var result = dynamicFunction(n, m, coins, matrix);

            Console.WriteLine(result);
        }

        private static long dynamicFunction(int n, int m, int[] coins, long[,] matrix)
        {
            if (n <= 0 || m <= 0)
            {
                return 0;
            }

            if (matrix[n, m] > 0)
            {
                return matrix[n, m];
            }

            int index = 0;
            int sum = index * coins[m - 1];
            long result = 0;
            while (sum < n)
            {
                result += dynamicFunction(n - sum, m - 1, coins, matrix);
                index++;
                sum = index * coins[m - 1];
            }

            if (sum == n)
            {
                result += 1;
            }

            matrix[n, m] = result;
            return result;
        }
    }
}
