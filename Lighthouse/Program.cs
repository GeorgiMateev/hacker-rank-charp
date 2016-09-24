using System;
using System.Linq;

namespace Lighthouse
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split().Select(x => int.Parse(x)).First();

            var plane = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    plane[i, j] = line[j] == '*' ? 1 : 0;
                }
            }


            //int n = 9;
            //var plane = new int[n, n];
            //var plane1 = new string[,] {
            //    { "*", "*", "*", "*", "*", "*", "*", "*", "*"},
            //    { "*", "*", "*", "*", ".", "*", "*", "*", "*"},
            //    { "*", "*", ".", ".", ".", ".", ".", "*", "*"},
            //    { "*", "*", ".", ".", ".", ".", ".", "*", "*"},
            //    { "*", ".", ".", ".", ".", ".", ".", ".", "*"},
            //    { "*", "*", ".", ".", ".", ".", ".", "*", "*"},
            //    { "*", "*", ".", ".", ".", ".", ".", "*", "*"},
            //    { "*", "*", "*", "*", ".", "*", "*", "*", "*"},
            //    { "*", "*", "*", "*", "*", "*", "*", "*", "*"},
            //};

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        plane[i, j] = plane1[i, j] == "*" ? 1 : 0;
            //    }
            //}

            int maxRadius = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (plane[i, j] == 1) continue;

                    int radius = findRadius(plane, i, j, n);

                    var possible = isPosibleCirlce(plane, i, j, radius);

                    if (possible)
                    {
                        maxRadius = radius > maxRadius ? radius : maxRadius;
                    }
                }
            }

            Console.WriteLine(maxRadius.ToString());
        }

        private static bool isPosibleCirlce(int[,]plane, int i, int j, int radius)
        {
            for (int k = i - radius; k <= i + radius; k++)
            {
                for (int p = j - radius; p <= j + radius; p++)
                {
                    if (Math.Sqrt((i - k) * (i - k) + (j - p) * (j - p)) <= radius && plane[k, p] == 1) return false;
                }
            }

            return true;
        }

        private static int findRadius(int[,] plane, int y, int x, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (x - i < 0 || plane[y, x - i] == 1) return i - 1;

                if (y - i < 0 || plane[y - i, x] == 1) return i - 1;

                if (x + i >= n || plane[y, x + i] == 1) return i - 1;

                if (y + i >= n || plane[y + i, x] == 1) return i - 1;
            }

            return 0;
        }
    }
}
