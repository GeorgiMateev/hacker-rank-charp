using System;
using System.Linq;

namespace TreasureHunting
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().Select(c => double.Parse(c)).ToArray();
            var line2 = Console.ReadLine().Split().Select(c => double.Parse(c)).ToArray();

            var x = line[0];
            var y = line[1];

            var a = line2[0];
            var b = line2[1];

            double n = (y * a - x * b) / (a * a + b * b);
            double k = (x + n * b) / a;

            Console.WriteLine(k.ToString());
            Console.WriteLine(n.ToString());
        }
    }
}
