using System;
using System.Collections.Generic;

namespace Ejercicio1.Interfaces;

public interface IEnrollable
{
    int EnrollmentId { get; set; }
    DateTime EnrollmentDate { get;  }
    string Status { get; }
    IStudent Student { get; set; }
    List<ICourse> Courses { get; set; }
    
    void RegisterEnrollment();
    void CancelEnrollment();
}