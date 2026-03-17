using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class Payment : IPayment
{
    public decimal TotalCost { get; set; }
    private decimal _amountPaid;
    public IEnrollment EnrollmentContext { get; set; }
    public decimal AmountPaid => _amountPaid;
    private IPaymentProcessor _paymentProcessor;

    public Payment(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
        _amountPaid = 0;
        TotalCost = 0;
    }

    public decimal CalculatePendingAmount()
    {
        return TotalCost - _amountPaid;
    }
    public IEnrollment GetEnrollmentContext()
    {
        return EnrollmentContext;
    }
    public void MakePayment(decimal amount)
    {
        _paymentProcessor.ProcessPayment(amount, this);
    }

    public bool IsFullyPaid()
    {
        return _amountPaid >= TotalCost;
    }
    
    public void AddPayment(decimal amount)
    {
        _amountPaid += amount;
    }
}