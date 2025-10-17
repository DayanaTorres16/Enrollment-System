using System;
using System.Collections.Generic;
using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;

public class Enrollment : IEnrollable
{
    public int EnrollmentId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; private set; }
    public decimal TotalCost { get; set; }
    public IStudent Student { get; set; }
    public List<ICourse> Courses { get; set; }
    public IResponsible Responsible { get; set; }
    public Payment payment;

    public Enrollment()
    {
        Courses = new List<ICourse>();
        Status = "Pending";
        payment = new Payment();
    }

    public void RegisterEnrollment()
    {
        if (ValidateEnrollment())
        {
            Status = "Active";
            EnrollmentDate = DateTime.Now;
            payment.TotalCost = this.TotalCost;
        }
        else
        {
            throw new InvalidOperationException("Enrollment could not be registered");
        }
    }

    public void CancelEnrollment()
    {
        if (Status == "Active")
        {
            Status = "Canceled";
        }
        else
        {
            throw new InvalidOperationException("Enrollment cannot be canceled.");
        }
    }
    public decimal CalculatePendingAmount()
    {
        return payment.CalculatePendingAmount();
    }
    public void MakePayment(decimal amount)
    {
        payment.MakePayment(amount);
    }
    public bool IsFullyPaid()
    {
        return payment.IsFullyPaid();
    }
    public bool ValidateEnrollment()
    {
        return Student != null && 
               Courses.Count > 0 && 
               TotalCost > 0 && 
               Responsible != null;
    }
}