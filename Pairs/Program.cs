using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().Select(x => int.Parse(x));
            var n = line.First();
            var k = line.Last();

            var arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            arr.Sort();

            var count = 0;

            for (int i = 0; i < arr.Count - 1; i++)
            {
                var l = i + 1;
                var r = arr.Count - 1;

                while (l <= r)
                {
                    var mid = (l + r) / 2;

                    var diff = Math.Abs(arr[i] - arr[mid]);

                    if (diff == k)
                    {
                        count++;
                        break;
                    }
                    else if (diff > k)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
