using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clique
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = int.Parse(Console.ReadLine());

            var queries = new KeyValuePair<int, int>[q];

            for (int i = 0; i < q; i++)
            {
                var line = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

                queries[i] = new KeyValuePair<int, int>(line[0], line[1]);
            }

            for (int i = 0; i < q; i++)
            {
                var n = queries[i].Key;
                var m = queries[i].Value;

                var r = n;
                var l = 1;

                var mC = 0d;

                var mid = 0;
                var maxMid = mid;
                var maxmC = -1d;

                while (l <= r)
                {
                    mid = (l + r) / 2;

                    mC = (n*n - (n % mid) * Math.Ceiling((double)n/mid) * Math.Ceiling((double)n / mid) - (mid - (n % mid)) * Math.Floor((double)n/mid) * Math.Floor((double)n / mid)) / 2d;

                    if (mC == m)
                    {
                        maxMid = mid - 1;
                        break;
                    }
                    else if (mC > m)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        if (mC > maxmC)
                        {
                            maxmC = mC;
                            maxMid = mid;
                        }
                        l = mid + 1;
                    }
                }

                Console.WriteLine(maxMid + 1);
            }
        }
    }
}
