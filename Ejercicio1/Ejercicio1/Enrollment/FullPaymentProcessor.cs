using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class FullPaymentProcessor : IPaymentProcessor
{
    public string PaymentType => "Full Payment";

    public void ProcessPayment(decimal amount, Payment payment)
    {
        if (amount <= 0)
            throw new ArgumentException("The amount must be greater than 0");

        if (amount > payment.CalculatePendingAmount())
            throw new InvalidOperationException("The amount exceeds the debt.");

        payment.AmountPaid += amount;
    }
}