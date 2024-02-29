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

            // Menampilkan hasil skor untuk setiap array
            Console.WriteLine($"Hasil array 1: {hasil1} (Array: {string.Join(", ", arr1)})");
            Console.WriteLine($"Hasil array 2: {hasil2} (Array: {string.Join(", ", arr2)})");
            Console.WriteLine($"Hasil array 3: {hasil3} (Array: {string.Join(", ", arr3)})");
        }

        // Fungsi untuk menghitung skor dari sebuah array
        static int ScoreArray(int[] arr)
        {
            int hasil = 0; // Inisialisasi nilai hasil skor

            foreach (int num in arr)
            {
                if (num % 2 == 0) // Jika angka genap
                {
                    hasil += 1; // Tambahkan 1 ke hasil skor
                }
                else if (num % 2 != 0) // Jika angka ganjil
                {
                    hasil += 3; // Tambahkan 3 ke hasil skor
                }
                if (num == 8) // Jika angka adalah 8
                {
                    hasil += 5; // Tambahkan 5 ke hasil skor
                }
            }

            return hasil; // Mengembalikan hasil skor
        }
    }
}
