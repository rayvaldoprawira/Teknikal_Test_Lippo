using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentAllocation
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice { InvoiceNumber = "Tagihan#1", DueDate = new DateTime(2023, 1, 10), Amount = 165000 },
                new Invoice { InvoiceNumber = "Tagihan#3", DueDate = new DateTime(2023, 1, 20), Amount = 130000 },
                new Invoice { InvoiceNumber = "Tagihan#5", DueDate = new DateTime(2023, 2, 10), Amount = 95500 },
                new Invoice { InvoiceNumber = "Tagihan#2", DueDate = new DateTime(2023, 2, 15), Amount = 80000 },
                new Invoice { InvoiceNumber = "Tagihan#4", DueDate = new DateTime(2023, 3, 25), Amount = 416000 }
            };

            Console.Write("Input Payment: ");
            string paymentInput = Console.ReadLine();

            if (!decimal.TryParse(paymentInput, out decimal payment) || payment < 0)
            {
                Console.WriteLine("Invalid payment amount. Payment amount must be a non-negative number.");
                return;
            }

            decimal remainingPayment = payment;
            List<Invoice> allocatedInvoices = new List<Invoice>();

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

            Console.WriteLine("\nInvoice Allocation:");
            Console.WriteLine("No.\tInvoice Number\tDue Date\tAmount\tAllocated Amount");

            int i = 1;
            foreach (var invoice in allocatedInvoices)
            {
                Console.WriteLine($"{i++}\t{invoice.InvoiceNumber}\t{invoice.DueDate.ToShortDateString()}\t{invoice.Amount}\t{invoice.AllocatedAmount}");
            }

            // Calculate Total Undue and Total Overdue using LINQ
            DateTime currentDate = new DateTime(2023, 3, 25); // Current date
            decimal totalUndue = invoices.Where(inv => inv.DueDate > currentDate).Sum(inv => inv.Amount);
            decimal totalOverdue = invoices.Where(inv => inv.DueDate <= currentDate).Sum(inv => inv.Amount);

            Console.WriteLine($"\nTotal Undue: {totalUndue}");
            Console.WriteLine($"Total Overdue: {totalOverdue}");
        }
    }

    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AllocatedAmount { get; set; }
    }
}
