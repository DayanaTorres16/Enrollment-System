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

    public bool CanProcessPayment(decimal amount, Payment payment, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (amount <= 0)
        {
            errorMessage = "The amount must be greater than 0";
            return false;
        }

        if (amount > payment.CalculatePendingAmount())
        {
            errorMessage = "The amount exceeds the debt.";
            return false;
        }

        decimal minimumPayment = payment.TotalCost * (_minimumPaymentPercentage / 100);
        decimal currentTotal = payment.AmountPaid + amount;

        if (currentTotal < minimumPayment && !payment.IsFullyPaid())
        {
            errorMessage = $"Minimum payment required: ${minimumPayment:N2}";
            return false;
        }

        return true;
    }

    public void ProcessPayment(decimal amount, Payment payment)
    {
        if (!CanProcessPayment(amount, payment, out string errorMessage))
            throw new InvalidOperationException(errorMessage);

        payment.AddPayment(amount);
    }
}