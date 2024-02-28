using System;
using System.Collections.Generic;
using System.Linq;

public class Invoice
{
    public string Number { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
}

public class Payment
{
    public string PaymentNumber { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
}

public class Penalty
{
    public string InvoiceNumber { get; set; }
    public int NoPenalty { get; set; }
    public decimal TagihanOverdue { get; set; }
    public int HariKeterlambatan { get; set; }
    public decimal AmountPenalty { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        // Sample data
        DateTime currentDate = new DateTime(2023, 4, 29);

        List<Invoice> invoices = new List<Invoice>
        {
            new Invoice { Number = "Tagihan#1", DueDate = new DateTime(2023, 1, 10), TotalAmount = 165000 },
            new Invoice { Number = "Tagihan#3", DueDate = new DateTime(2023, 1, 20), TotalAmount = 130000 },
            new Invoice { Number = "Tagihan#5", DueDate = new DateTime(2023, 2, 10), TotalAmount = 95500 },
            new Invoice { Number = "Tagihan#2", DueDate = new DateTime(2023, 2, 15), TotalAmount = 80000 },
            new Invoice { Number = "Tagihan#4", DueDate = new DateTime(2023, 3, 30), TotalAmount = 416000 }
        };

        List<Payment> payments = new List<Payment>
        {
            new Payment { PaymentNumber = "Payment#1", InvoiceNumber = "Tagihan#1", PaymentDate = new DateTime(2023, 1, 10), PaymentAmount = 165000 },
            new Payment { PaymentNumber = "Payment#2", InvoiceNumber = "Tagihan#3", PaymentDate = new DateTime(2023, 2, 20), PaymentAmount = 130000 },
            new Payment { PaymentNumber = "Payment#2", InvoiceNumber = "Tagihan#5", PaymentDate = new DateTime(2023, 2, 20), PaymentAmount = 95500 },
            new Payment { PaymentNumber = "Payment#3", InvoiceNumber = "Tagihan#2", PaymentDate = new DateTime(2023, 2, 25), PaymentAmount = 30000 },
            new Payment { PaymentNumber = "Payment#4", InvoiceNumber = "Tagihan#2", PaymentDate = new DateTime(2023, 3, 30), PaymentAmount = 50000 },
            new Payment { PaymentNumber = "Payment#4", InvoiceNumber = "Tagihan#4", PaymentDate = new DateTime(2023, 3, 30), PaymentAmount = 50000 }
        };

        List<Penalty> penalties = GeneratePenalties(invoices, payments, currentDate);

        // Display the dataset
        Console.WriteLine("Hasilkan dataset sebagai berikut: Hari ini = 29 Apr 23");
        Console.WriteLine("No Tagihan\tNo Penalty\tTagihan Overdue\tHari Keterlambatan\tAmount Penalty");
        foreach (var penalty in penalties)
        {
            Console.WriteLine($"{penalty.InvoiceNumber}\t{penalty.NoPenalty}\t{penalty.TagihanOverdue}\t{penalty.HariKeterlambatan}\t{penalty.AmountPenalty}");
        }
    }

    public static List<Penalty> GeneratePenalties(List<Invoice> invoices, List<Payment> payments, DateTime currentDate)
    {
        List<Penalty> penalties = new List<Penalty>();

        foreach (var invoice in invoices)
        {
            var latestPayment = payments.Where(p => p.InvoiceNumber == invoice.Number)
                                        .OrderByDescending(p => p.PaymentDate)
                                        .FirstOrDefault();

            if (latestPayment == null || latestPayment.PaymentDate > invoice.DueDate)
            {
                penalties.Add(new Penalty
                {
                    InvoiceNumber = invoice.Number,
                    NoPenalty = 1,
                    TagihanOverdue = invoice.TotalAmount,
                    HariKeterlambatan = (currentDate - invoice.DueDate).Days,
                    AmountPenalty = invoice.TotalAmount * 0.002m * (currentDate - invoice.DueDate).Days
                });
            }
            else
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

        return penalties;
    }
}
