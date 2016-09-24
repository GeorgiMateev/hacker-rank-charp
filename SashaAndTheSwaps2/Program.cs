using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SashaAndTheSwaps2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            var dynamicMatrix = new int[n + 1, n + 1];

            for (int i = 1; i < n; i++)
            {
                var count = dynamicFunction(n, i, dynamicMatrix) % (1000000000 + 7);
                Console.Write(count + " ");
            }
        }

        private static int dynamicFunction(int n, int k, int[,] matrix)
        {
            if (n <= 1 || k < 1)
            {
                return 0;
            }

            if (n == k)
            {
                return 0;
            }

            int f1;
            if (matrix[n - 1, k] > 0)
            {
                f1 = matrix[n - 1, k];
            }
            else
            {
                f1 = dynamicFunction(n - 1, k, matrix);
            }

            int f2;
            if (matrix[n - 1, k - 1] > 0)
            {
                f2 = matrix[n - 1, k - 1];
            }
            else
            {
                f2 = dynamicFunction(n - 1, k - 1, matrix);
            }

            var result =  f1 + f2 + n - 1;
            matrix[n, k] = result;

            return result;
        }
    }
}
