using System;
using System.Collections.Generic;
using System.Linq;

// Definisi kelas Invoice untuk merepresentasikan data tagihan
public class Invoice
{
    public string Number { get; set; } // Nomor tagihan
    public DateTime DueDate { get; set; } // Tanggal jatuh tempo
    public decimal TotalAmount { get; set; } // Jumlah total tagihan
}

// Definisi kelas Payment untuk merepresentasikan data pembayaran
public class Payment
{
    public string PaymentNumber { get; set; } // Nomor pembayaran
    public string InvoiceNumber { get; set; } // Nomor tagihan yang dibayarkan
    public DateTime PaymentDate { get; set; } // Tanggal pembayaran
    public decimal PaymentAmount { get; set; } // Jumlah pembayaran
}

// Definisi kelas Penalty untuk merepresentasikan data denda
public class Penalty
{
    public string InvoiceNumber { get; set; } // Nomor tagihan yang dikenai denda
    public int NoPenalty { get; set; } // Nomor denda
    public decimal TagihanOverdue { get; set; } // Jumlah tagihan yang jatuh tempo
    public int HariKeterlambatan { get; set; } // Jumlah hari keterlambatan
    public decimal AmountPenalty { get; set; } // Jumlah denda yang harus dibayarkan
}

// Program utama
public class Program
{
    static void Main(string[] args)
    {
        // Data contoh
        DateTime currentDate = new DateTime(2023, 4, 29); // Tanggal saat ini

        List<Invoice> invoices = new List<Invoice> // Daftar tagihan
        {
            new Invoice { Number = "Tagihan#1", DueDate = new DateTime(2023, 1, 10), TotalAmount = 165000 },
            new Invoice { Number = "Tagihan#3", DueDate = new DateTime(2023, 1, 20), TotalAmount = 130000 },
            new Invoice { Number = "Tagihan#5", DueDate = new DateTime(2023, 2, 10), TotalAmount = 95500 },
            new Invoice { Number = "Tagihan#2", DueDate = new DateTime(2023, 2, 15), TotalAmount = 80000 },
            new Invoice { Number = "Tagihan#4", DueDate = new DateTime(2023, 3, 30), TotalAmount = 416000 }
        };

        // Daftar pembayaran
        List<Payment> payments = new List<Payment> 
        {
            new Payment { PaymentNumber = "Payment#1", InvoiceNumber = "Tagihan#1", PaymentDate = new DateTime(2023, 1, 10), PaymentAmount = 165000 },
            new Payment { PaymentNumber = "Payment#2", InvoiceNumber = "Tagihan#3", PaymentDate = new DateTime(2023, 2, 20), PaymentAmount = 130000 },
            new Payment { PaymentNumber = "Payment#2", InvoiceNumber = "Tagihan#5", PaymentDate = new DateTime(2023, 2, 20), PaymentAmount = 95500 },
            new Payment { PaymentNumber = "Payment#3", InvoiceNumber = "Tagihan#2", PaymentDate = new DateTime(2023, 2, 25), PaymentAmount = 30000 },
            new Payment { PaymentNumber = "Payment#4", InvoiceNumber = "Tagihan#2", PaymentDate = new DateTime(2023, 3, 30), PaymentAmount = 50000 },
            new Payment { PaymentNumber = "Payment#4", InvoiceNumber = "Tagihan#4", PaymentDate = new DateTime(2023, 3, 30), PaymentAmount = 50000 }
        };

        // Menghasilkan denda
        List<Penalty> penalties = GeneratePenalties(invoices, payments, currentDate); 

        // Menampilkan hasil
        Console.WriteLine("Hasilkan dataset sebagai berikut: Hari ini = 29 Apr 23");
        Console.WriteLine("No Tagihan\tNo Penalty\tTagihan Overdue\tHari Keterlambatan\tAmount Penalty");
        foreach (var penalty in penalties)
        {
            Console.WriteLine($"{penalty.InvoiceNumber}\t{penalty.NoPenalty}\t{penalty.TagihanOverdue}\t{penalty.HariKeterlambatan}\t{penalty.AmountPenalty}");
        }
    }

    // Metode untuk menghasilkan denda
    public static List<Penalty> GeneratePenalties(List<Invoice> invoices, List<Payment> payments, DateTime currentDate)
    {
        // Inisialisasi daftar denda
        List<Penalty> penalties = new List<Penalty>(); 

        // Iterasi melalui setiap tagihan
        foreach (var invoice in invoices)
        {
            // Menemukan pembayaran terakhir
            var latestPayment = payments.Where(p => p.InvoiceNumber == invoice.Number) 
                                        .OrderByDescending(p => p.PaymentDate)
                                        .FirstOrDefault();

            // Jika tidak ada pembayaran atau pembayaran terakhir dilakukan setelah tanggal jatuh tempo
            if (latestPayment == null || latestPayment.PaymentDate > invoice.DueDate)
            {
                // Hitung denda berdasarkan jumlah hari keterlambatan
                penalties.Add(new Penalty
                {
                    InvoiceNumber = invoice.Number,
                    NoPenalty = 1,
                    TagihanOverdue = invoice.TotalAmount,
                    HariKeterlambatan = (currentDate - invoice.DueDate).Days,
                    AmountPenalty = invoice.TotalAmount * 0.002m * (currentDate - invoice.DueDate).Days
                });
            }
            else // Jika ada pembayaran, hitung denda berdasarkan sisa tagihan dan jumlah hari keterlambatan sejak pembayaran terakhir
            {
                decimal remainingAmount = invoice.TotalAmount - latestPayment.PaymentAmount;
                if (remainingAmount > 0)
                {
                    penalties.Add(new Penalty
                    {
                        InvoiceNumber = invoice.Number,
                        NoPenalty = 1,
                        TagihanOverdue = remainingAmount,
                        HariKeterlambatan = (currentDate - latestPayment.PaymentDate).Days,
                        AmountPenalty = remainingAmount * 0.002m * (currentDate - latestPayment.PaymentDate).Days
                    });
                }
            }
        }

        // Mengembalikan daftar denda
        return penalties; 
    }
}
