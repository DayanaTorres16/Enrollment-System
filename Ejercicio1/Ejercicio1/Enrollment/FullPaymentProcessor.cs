using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class FullPaymentProcessor : IPaymentProcessor
{
    public string PaymentType => "Full Payment";

    public bool CanProcessPayment(decimal amount, IPayment payment, out string errorMessage)
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

        return true;
    }

    public void ProcessPayment(decimal amount, IPayment payment)
    {
        if (!CanProcessPayment(amount, payment, out string errorMessage))
            throw new InvalidOperationException(errorMessage);

        payment.AddPayment(amount);
    }
}