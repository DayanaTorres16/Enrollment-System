using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class PartialPaymentProcessor : IPaymentProcessor
{
    private readonly decimal _minimumPaymentPercentage;

    public PartialPaymentProcessor(decimal minimumPaymentPercentage = 30m)
    {
        _minimumPaymentPercentage = minimumPaymentPercentage;
    }

    public string PaymentType => "Partial Payment";

    public void ProcessPayment(decimal amount, Payment payment)
    {
        if (amount <= 0)
            throw new ArgumentException("The amount must be greater than 0");

        decimal minimumPayment = payment.TotalCost * (_minimumPaymentPercentage / 100);
        decimal currentTotal = payment.AmountPaid + amount;

        if (currentTotal < minimumPayment && !payment.IsFullyPaid())
            throw new InvalidOperationException($"Minimum payment required: ${minimumPayment:N2}");

        if (amount > payment.CalculatePendingAmount())
            throw new InvalidOperationException("The amount exceeds the debt.");

        payment.AmountPaid += amount;
    }
}