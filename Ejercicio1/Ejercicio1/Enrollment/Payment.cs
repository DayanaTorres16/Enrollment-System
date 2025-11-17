using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class Payment : IPayment
{
    public decimal TotalCost { get; set; }
    private decimal _amountPaid;
    public decimal AmountPaid => _amountPaid;
    private IPaymentProcessor _paymentProcessor;
    private readonly IEnrollable _enrollment;

    public Payment(IPaymentProcessor paymentProcessor, IEnrollable enrollment)
    {
        _paymentProcessor = paymentProcessor;
        _enrollment = enrollment;
        _amountPaid = 0;
    }

    public decimal CalculatePendingAmount()
    {
        return TotalCost - _amountPaid;
    }
    public IEnrollable GetEnrollmentContext()
    {
        return _enrollment;
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