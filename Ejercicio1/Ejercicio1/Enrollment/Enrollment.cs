using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
using System.Linq;

namespace Ejercicio1.Enrollment;

public class Enrollment : IEnrollment
{
    public int EnrollmentId { get; set; }
    public DateTime EnrollmentDate { get; private set; }
    public string Status { get; private set; }
    public IStudent Student { get; set; }
    public List<ICourse> Courses { get; set; }

    private readonly IPayment _payment;
    private readonly IEnrollmentValidator _validator;
    private readonly ICostCalculatorFactory _costCalculatorFactory;
    private readonly IPaymentProcessor _paymentProcessor;

    public decimal TotalCost => _payment.TotalCost;
    public decimal AmountPaid => _payment.AmountPaid;
    public IPaymentProcessor PaymentProcessor => _paymentProcessor;

    public Enrollment(
        ICostCalculatorFactory costCalculatorFactory, 
        IPaymentProcessor paymentProcessor, 
        IPayment payment, 
        IEnrollmentValidator validator)
    {
        Courses = new List<ICourse>();
        Status = "Pending";
        _payment = payment;
        _validator = validator;
        _costCalculatorFactory = costCalculatorFactory;
        _paymentProcessor = paymentProcessor;
    }

    public void RegisterEnrollment()
    {
        if (Student == null)
        {
            throw new InvalidOperationException("No se puede registrar una matrícula sin un estudiante asignado.");
        }
        
        this.Courses = this.Student.EnrolledCourses != null 
            ? this.Student.EnrolledCourses.ToList() 
            : new List<ICourse>();
        
        if (!_validator.ValidateEnrollment(this, out string errorMessage))
        {
            throw new InvalidOperationException($"Enrollment could not be registered: {errorMessage}");
        }

        Status = "Active";
        EnrollmentDate = DateTime.Now;
        
        ICostCalculator calculator = _costCalculatorFactory.CreateCalculator(this.Courses);
        _payment.TotalCost = calculator.CalculateTotalCost(this.Courses);
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