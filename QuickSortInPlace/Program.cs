using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortInPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                var p = Partition(arr, low, high);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();

                QuickSort(arr, low, p - 1);
                QuickSort(arr, p + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            var pivot = arr[high];
            var i = low;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    var c = arr[i];
                    arr[i] = arr[j];
                    arr[j] = c;

                    i++;
                }
            }

            var a = arr[i];
            arr[i] = arr[high];
            arr[high] = a;

            return i;
        }
    }
}
