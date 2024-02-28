using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            Console.WriteLine("Algoritma A:");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Algoritma B:");
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Algoritma C:");

            //int n = 5; // Jumlah baris yang diinginkan
            int num = 1; // Angka awal
            int increment = 1; // Langkah pertambahan atau pengurangan angka

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(num);

                    // Mengatur kondisi untuk perulangan acending dan descending
                    num += increment;

                    // Jika mencapai angka 5 atau 1, ubah arah perulangan
                    if (num == 5 || num == 1)
                    {
                        increment *= -1;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Algoritma D:");

            //int n = 5; // Ukuran matriks
            int[,] matrix = new int[n, n]; // Membuat matriks

            // Mengisi matriks sesuai pola yang diinginkan
            //int num = 1;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = num++;
                    }
                }
                else
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        matrix[i, j] = num++;
                    }
                }
            }

            // Mencetak matriks
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
