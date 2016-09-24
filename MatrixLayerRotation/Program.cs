using System;
using System.Linq;

namespace MatrixLayerRotation
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var m = input[0];
            var n = input[1];
            var r = input[2];

            var matrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                var line = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            //var m = 5;
            //var n = 4;
            //var r = 7;

            //var matrix = new int[,] {
            //    { 1, 2, 3, 4},
            //    { 7, 8, 9, 10},
            //    { 13, 14, 15, 16},
            //    { 19, 20, 21, 22},
            //    { 25, 26, 27, 28}
            //};

            //var m = 2;
            //var n = 2;
            //var r = 3;

            //var matrix = new int[,] {
            //    { 1, 2},
            //    { 4, 3}
            //};

            int radius = 0;

            int rowsBorder = m - 1 - radius;
            int columnsBorder = n - 1 - radius;

            while (radius < rowsBorder && radius < columnsBorder)
            {
                int actualSteps = r == 1 ? 1 : r % ((m + n - radius * 4 - 2) * 2);

                if (actualSteps > 0)
                {
                    
                    var flat = new int[(rowsBorder - radius) * 2 + (columnsBorder - radius) * 2];

                    int flatIndex = 0;

                    //flatten the ring
                    for (int cs = radius; cs < columnsBorder; cs++)
                    {
                        flat[flatIndex] = matrix[radius, cs];
                        flatIndex++;
                    }

                    for (int rs = radius; rs < rowsBorder; rs++)
                    {
                        flat[flatIndex] = matrix[rs, columnsBorder];
                        flatIndex++;
                    }

                    for (int c2 = columnsBorder; c2 > radius; c2--)
                    {
                        flat[flatIndex] = matrix[rowsBorder, c2];
                        flatIndex++;
                    }

                    for (int r2 = rowsBorder; r2 > radius; r2--)
                    {
                        flat[flatIndex] = matrix[r2, radius];
                        flatIndex++;
                    }

                    //copy the shifted elements
                    flatIndex = actualSteps;

                    for (int cs = radius; cs < columnsBorder; cs++)
                    {
                        matrix[radius, cs] = flat[flatIndex];
                        flatIndex++;

                        if (flatIndex == flat.Length)
                        {
                            flatIndex = 0;
                        }
                    }
                    
                    for (int rs = radius; rs < rowsBorder; rs++)
                    {
                        matrix[rs, columnsBorder] = flat[flatIndex];
                        flatIndex++;
                        if (flatIndex == flat.Length)
                        {
                            flatIndex = 0;
                        }
                    }

                    for (int c2 = columnsBorder; c2 > radius; c2--)
                    {
                        matrix[rowsBorder, c2] = flat[flatIndex];
                        flatIndex++;

                        if (flatIndex == flat.Length)
                        {
                            flatIndex = 0;
                        }
                    }

                    for (int r2 = rowsBorder; r2 > radius; r2--)
                    {
                        matrix[r2, radius] = flat[flatIndex];
                        flatIndex++;

                        if (flatIndex == flat.Length)
                        {
                            flatIndex = 0;
                        }
                    }
                }

                radius++;
                rowsBorder = m - 1 - radius;
                columnsBorder = n - 1 - radius;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j].ToString() + ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
