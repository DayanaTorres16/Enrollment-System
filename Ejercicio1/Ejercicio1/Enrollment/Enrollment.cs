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

    private IPayment _payment;
    private EnrollmentValidator _validator;
    private ICostCalculator _costCalculator;

    public decimal TotalCost => _payment.TotalCost;
    public decimal AmountPaid => _payment.AmountPaid;

    public Enrollment(ICostCalculator costCalculator, IPaymentProcessor paymentProcessor, IPayment payment, EnrollmentValidator validator )
    {
        Courses = new List<ICourse>();
        Status = "Pending";
        _payment = payment;
        _validator = validator;
        _costCalculator = costCalculator;
    }

    public void AddValidationRule(IValidationRule rule)
    {
        _validator.AddValidationRule(rule);
    }

    public void SetCostCalculator(ICostCalculator calculator)
    {
        _costCalculator = calculator;
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