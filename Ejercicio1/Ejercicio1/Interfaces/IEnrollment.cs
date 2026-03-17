using System;
using System.Collections.Generic;

namespace Ejercicio1.Interfaces;

public interface IEnrollment
{
    int EnrollmentId { get; set; }
    DateTime EnrollmentDate { get;  }
    string Status { get; }
    IStudent Student { get; set; }
    List<ICourse> Courses { get; set; }
    
    decimal TotalCost { get; }
    decimal AmountPaid { get; }
    
    void RegisterEnrollment();
    void CancelEnrollment();

    void MakePayment(decimal amount);
}