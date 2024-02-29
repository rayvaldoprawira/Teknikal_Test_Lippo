using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentAllocation
{
    class Program
    {
        // Program entry point
        public static void Main(string[] args)
        {
            // List of invoices with due dates and amounts
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice { InvoiceNumber = "Tagihan#1", DueDate = new DateTime(2023, 1, 10), Amount = 165000 },
                new Invoice { InvoiceNumber = "Tagihan#3", DueDate = new DateTime(2023, 1, 20), Amount = 130000 },
                new Invoice { InvoiceNumber = "Tagihan#5", DueDate = new DateTime(2023, 2, 10), Amount = 95500 },
                new Invoice { InvoiceNumber = "Tagihan#2", DueDate = new DateTime(2023, 2, 15), Amount = 80000 },
                new Invoice { InvoiceNumber = "Tagihan#4", DueDate = new DateTime(2023, 3, 25), Amount = 416000 }
            };

            // Meminta pengguna untuk memasukkan jumlah pembayaran
            Console.Write("Input Payment: ");
            string paymentInput = Console.ReadLine();

            // Validasi dan parsing jumlah pembayaran
            if (!decimal.TryParse(paymentInput, out decimal payment) || payment < 0)
            {
                Console.WriteLine("Invalid payment amount. Payment amount must be a non-negative number.");
                return;
            }

            // Memperuntukkan pembayaran untuk setiap tagihan
            decimal remainingPayment = payment;
            List<Invoice> allocatedInvoices = new List<Invoice>();

            // Mengulangi setiap tagihan yang telah diurutkan berdasarkan tanggal jatuh tempo
            foreach (var invoice in invoices.OrderBy(x => x.DueDate))
            {
                if (remainingPayment >= invoice.Amount)
                {
                    invoice.AllocatedAmount = invoice.Amount;
                    remainingPayment -= invoice.Amount;
                }
                else
                {
                    invoice.AllocatedAmount = remainingPayment;
                    remainingPayment = 0;
                }

                allocatedInvoices.Add(invoice);

                if (remainingPayment == 0)
                {
                    break;
                }
            }

            // Menampilkan tagihan yang sudah dialokasikan
            Console.WriteLine("\nInvoice Allocation:");
            Console.WriteLine("No.\tInvoice Number\tDue Date\tAmount\tAllocated Amount");

            int i = 1;
            foreach (var invoice in allocatedInvoices)
            {
                Console.WriteLine($"{i++}\t{invoice.InvoiceNumber}\t{invoice.DueDate.ToShortDateString()}\t{invoice.Amount}\t{invoice.AllocatedAmount}");
            }

            // Menghitung Total Belum Jatuh Tempo dan Total Telat Bayar menggunakan LINQ
            // Tanggal saat ini
            DateTime currentDate = new DateTime(2023, 3, 25); 
            decimal totalUndue = invoices.Where(inv => inv.DueDate > currentDate).Sum(inv => inv.Amount);
            decimal totalOverdue = invoices.Where(inv => inv.DueDate <= currentDate).Sum(inv => inv.Amount);

            // Menampilkan total tagihan yang belum jatuh tempo dan total tagihan yang telat bayar
            Console.WriteLine($"\nTotal Undue: {totalUndue}");
            Console.WriteLine($"Total Overdue: {totalOverdue}");
        }
    }

    // Kelas yang merepresentasikan sebuah tagihan
    public class Invoice
    {
        public string InvoiceNumber { get; set; } // Nomor tagihan
        public DateTime DueDate { get; set; } // Tanggal jatuh tempo
        public decimal Amount { get; set; } // Jumlah tagihan
        public decimal AllocatedAmount { get; set; } // Jumlah pembayaran yang dialokasikan
    }
}
