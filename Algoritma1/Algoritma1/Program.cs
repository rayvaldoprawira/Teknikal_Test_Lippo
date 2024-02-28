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

            int score1 = ScoreArray(arr1);
            int score2 = ScoreArray(arr2);
            int score3 = ScoreArray(arr3);

            Console.WriteLine($"Score for array 1: {score1} (Array: {string.Join(", ", arr1)})");
            Console.WriteLine($"Score for array 2: {score2} (Array: {string.Join(", ", arr2)})");
            Console.WriteLine($"Score for array 3: {score3} (Array: {string.Join(", ", arr3)})");
        }

        static int ScoreArray(int[] arr)
        {
            int score = 0;

            foreach (int num in arr)
            {
                if (num % 2 == 0)
                {
                    score += 1;
                }
                else if (num % 2 != 0)
                {
                    score += 3;
                }
                if (num == 8)
                {
                    score += 5;
                }
            }

            return score;
        }
    }
}