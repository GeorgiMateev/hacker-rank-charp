using System;

namespace UnexpectedProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var m = int.Parse(Console.ReadLine());

            int delimeter = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                var isKleene = isFromKleeneStar(s.Substring(0, i + 1), s);
                if (isKleene)
                {
                    delimeter = i + 1;
                    break;
                }
            }
            //var firstChar = s[0];
            //var controlStr = new string(firstChar, s.Length);

            //var delimeter = s == controlStr ? 1 : s.Length;

            var tl = m / delimeter;
            var output = tl % (Math.Pow(10, 9) + 7);

            Console.WriteLine(output);
        }

        private static bool isFromKleeneStar(string substr, string str)
        {
            if (str == "")
            {
                return true;
            }

            if (str.IndexOf(substr) == 0)
            {
                return isFromKleeneStar(substr, str.Substring(substr.Length));
            }
            else return false;
        }
    }
}
