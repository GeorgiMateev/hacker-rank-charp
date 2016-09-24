using System;
using System.Linq;

namespace Kangaroo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();

            double jumpsNumber = (input[0] - input[2]) / (input[3] - input[1]);

            if (jumpsNumber >= 0 && jumpsNumber % 1 == 0)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
