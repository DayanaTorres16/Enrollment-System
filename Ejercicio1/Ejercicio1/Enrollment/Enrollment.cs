using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class Enrollment : IEnrollable
{
    public int EnrollmentId { get; set; }
    public DateTime EnrollmentDate { get; private set; }
    public string Status { get; private set; }
    public IStudent Student { get; set; }
    public List<ICourse> Courses { get; set; }

    private readonly IPayment _payment;
    private readonly IEnrollmentValidator _validator;
    private readonly ICostCalculator _costCalculator;
    private readonly IPaymentProcessor _paymentProcessor;

    public decimal TotalCost => _payment.TotalCost;
    public decimal AmountPaid => _payment.AmountPaid;
    public IPaymentProcessor PaymentProcessor => _paymentProcessor; 

    public Enrollment(ICostCalculator costCalculator, IPaymentProcessor paymentProcessor, IPayment payment, IEnrollmentValidator validator)
    {
        Courses = new List<ICourse>();
        Status = "Pending";
        _payment = payment;
        _validator = validator;
        _costCalculator = costCalculator;
        _paymentProcessor = paymentProcessor;
    }

    public void RegisterEnrollment()
    {
        if (!_validator.ValidateEnrollment(this, out string errorMessage))
        {
            throw new InvalidOperationException($"Enrollment could not be registered: {errorMessage}");
        }

        Status = "Active";
        EnrollmentDate = DateTime.Now;
        _payment.TotalCost = _costCalculator.CalculateTotalCost(Courses);
    }

    public void CancelEnrollment()
    {
        if (Status != "Active")
            throw new InvalidOperationException("Only active enrollments can be canceled.");

        Status = "Canceled";
    }

    public void MakePayment(decimal amount)
    {
        _payment.MakePayment(amount);
    }

    public decimal CalculatePendingAmount()
    {
        return _payment.CalculatePendingAmount();
    }

    public bool IsFullyPaid()
    {
        return _payment.IsFullyPaid();
    }
}