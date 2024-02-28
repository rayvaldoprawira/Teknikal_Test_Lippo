using System;
using System.Collections.Generic;

namespace PenaltyCalculator
{
    public class Invoice
    {
        public string Number { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Payment
    {
        public string Number { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class Penalty
    {
        public string InvoiceNumber { get; set; }
        public int PenaltyNumber { get; set; }
        public decimal OverdueAmount { get; set; }
        public int DaysOverdue { get; set; }
        public decimal PenaltyAmount { get; set; }
    }

    public class DataSet
    {
        public List<Invoice> Invoices { get; set; }
        public List<Payment> Payments { get; set; }

        public DataSet()
        {
            Invoices = new List<Invoice>
            {
                new Invoice { Number = "Tagihan#1", DueDate = new DateTime(2023, 1, 10), TotalAmount = 165000 },
                new Invoice { Number = "Tagihan#3", DueDate = new DateTime(2023, 1, 20), TotalAmount = 130000 },
                new Invoice { Number = "Tagihan#5", DueDate = new DateTime(2023, 2, 10), TotalAmount = 95500 },
                new Invoice { Number = "Tagihan#2", DueDate = new DateTime(2023, 2, 15), TotalAmount = 80000 },
                new Invoice { Number = "Tagihan#4", DueDate = new DateTime(2023, 3, 30), TotalAmount = 416000 }
            };

            Payments = new List<Payment>
            {
                new Payment { Number = "Payment#1", InvoiceNumber = "Tagihan#1", PaymentDate = new DateTime(2023, 1, 10), Amount = 165000 },
                new Payment { Number = "Payment#2", InvoiceNumber = "Tagihan#3", PaymentDate = new DateTime(2023, 2, 20), Amount = 130000 },
                new Payment { Number = "Payment#2", InvoiceNumber = "Tagihan#5", PaymentDate = new DateTime(2023, 2, 20), Amount = 95500 },
                new Payment { Number = "Payment#3", InvoiceNumber = "Tagihan#2", PaymentDate = new DateTime(2023, 2, 25), Amount = 30000 },
                new Payment { Number = "Payment#4", InvoiceNumber = "Tagihan#2", PaymentDate = new DateTime(2023, 3, 30), Amount = 50000 },
                new Payment { Number = "Payment#4", InvoiceNumber = "Tagihan#4", PaymentDate = new DateTime(2023, 3, 30), Amount = 50000 }
            };
        }
    }
}