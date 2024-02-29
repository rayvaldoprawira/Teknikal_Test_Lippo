using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5; // Jumlah baris atau ukuran matriks

            // Algoritma A: Mencetak segitiga angka naik
            Console.WriteLine("Algoritma A:");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i); // Mencetak angka i sebanyak i kali
                }
                Console.WriteLine(); // Pindah ke baris baru setelah setiap baris tercetak
            }

            // Algoritma B: Mencetak segitiga angka turun
            Console.WriteLine("Algoritma B:");
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    Console.Write(j); // Mencetak angka j sebanyak j kali
                }
                Console.WriteLine(); // Pindah ke baris baru setelah setiap baris tercetak
            }

            // Algoritma C: Mencetak pola angka naik-turun
            Console.WriteLine("Algoritma C:");

            int num = 1; // Angka awal
            int increment = 1; // Langkah pertambahan atau pengurangan angka

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(num); // Mencetak angka num
                    num += increment; // Menambahkan atau mengurangkan angka sesuai langkah

                    // Mengatur arah perubahan angka
                    if (num == 5 || num == 1)
                    {
                        increment *= -1; // Mengubah langkah menjadi negatif
                    }
                }

                Console.WriteLine(); // Pindah ke baris baru setelah setiap baris tercetak
            }

            // Algoritma D: Mencetak pola angka di dalam matriks
            Console.WriteLine("Algoritma D:");

            int[,] matrix = new int[n, n]; // Matriks untuk menampung angka

            for (int i = 0; i < n; i++)
            {
                // Menentukan pola angka berdasarkan indeks baris
                if (i % 2 == 0) // Jika indeks genap, angka naik dari kiri ke kanan
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = num++; // Menyimpan angka ke dalam matriks
                    }
                }
                else // Jika indeks ganjil, angka turun dari kanan ke kiri
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        matrix[i, j] = num++; // Menyimpan angka ke dalam matriks
                    }
                }
            }

            // Mencetak matriks
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[j, i] + " "); // Mencetak elemen matriks
                }
                Console.WriteLine(); // Pindah ke baris baru setelah setiap baris tercetak
            }
        }
    }
}
