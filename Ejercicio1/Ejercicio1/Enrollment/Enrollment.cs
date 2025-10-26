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
    
    private Payment payment;
    private EnrollmentValidator validator;
    private EnrollmentCostCalculator costCalculator;

    public decimal TotalCost => payment.TotalCost;
    public decimal AmountPaid => payment.AmountPaid;

    public Enrollment()
    {
        Courses = new List<ICourse>();
        Status = "Pending";
        payment = new Payment();
        validator = new EnrollmentValidator();
        costCalculator = new EnrollmentCostCalculator();
    }

    public void RegisterEnrollment()
    {
        if (!validator.ValidateEnrollment(this))
        {
            throw new InvalidOperationException("Enrollment could not be registered: Invalid data.");
        }

        Status = "Active";
        EnrollmentDate = DateTime.Now;
        payment.TotalCost = costCalculator.CalculateTotalCost(Courses);
    }

    public void CancelEnrollment()
    {
        if (Status != "Active")
        {
            throw new InvalidOperationException("Only active enrollments can be canceled.");
        }
        Status = "Canceled";
    }

    public void MakePayment(decimal amount)
    {
        payment.MakePayment(amount);
    }

    public decimal CalculatePendingAmount()
    {
        return payment.CalculatePendingAmount();
    }

    public bool IsFullyPaid()
    {
        return payment.IsFullyPaid();
    }
}