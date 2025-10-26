using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class EnrollmentCostCalculator
{
    private const decimal CourseFeePerCredit = 200000m;

    public decimal CalculateTotalCost(List<ICourse> courses)
    {
        if (courses == null || courses.Count == 0)
        {
            return 0;
        }
        
        int totalCredits = 0;
        foreach (var course in courses)
        {
            totalCredits += course.Credits;
        }
        
        return totalCredits * CourseFeePerCredit;
    }
}