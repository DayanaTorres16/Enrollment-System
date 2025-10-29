using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class Payment : IPayment
{
    public decimal TotalCost { get; set; }
    public decimal AmountPaid { get; set; }
    private IPaymentProcessor _paymentProcessor;

    public Payment(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public decimal CalculatePendingAmount()
    {
        return TotalCost - AmountPaid;
    }

    public void MakePayment(decimal amount)
    {
        _paymentProcessor.ProcessPayment(amount, this);
    }

    public bool IsFullyPaid()
    {
        return AmountPaid >= TotalCost;
    }
}