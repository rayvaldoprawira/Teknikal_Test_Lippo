using System;
using System.Linq;

namespace ScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 15, 25, 35 };
            int[] arr3 = { 8, 8 };

            int hasil1 = ScoreArray(arr1);
            int hasil2 = ScoreArray(arr2);
            int hasil3 = ScoreArray(arr3);

            Console.WriteLine($"Hasil array 1: {hasil1} (Array: {string.Join(", ", arr1)})");
            Console.WriteLine($"Hasil array 2: {hasil2} (Array: {string.Join(", ", arr2)})");
            Console.WriteLine($"Hasil array 3: {hasil3} (Array: {string.Join(", ", arr3)})");
        }

        static int ScoreArray(int[] arr)
        {
            int hasil = 0;

            foreach (int num in arr)
            {
                if (num % 2 == 0)
                {
                    hasil += 1;
                }
                else if (num % 2 != 0)
                {
                    hasil += 3;
                }
                if (num == 8)
                {
                    hasil += 5;
                }
            }

            return hasil;
        }
    }
}