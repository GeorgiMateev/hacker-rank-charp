using System;
class Solution
{
    static void Main(String[] args)
    {
        var q = int.Parse(Console.ReadLine());

        var queries = new int[q];

        for (int i = 0; i < q; i++)
        {
            var n = int.Parse(Console.ReadLine());
            queries[i] = n;
        }

        for (int i = 0; i < q; i++)
        {
            if (queries[i] % 2 == 0)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}