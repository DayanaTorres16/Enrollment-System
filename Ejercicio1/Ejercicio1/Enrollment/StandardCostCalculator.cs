using System;
using System.Collections.Generic;
using System.Linq;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class StandardCostCalculator : ICostCalculator
{
    private readonly decimal _costPerCredit;

    public StandardCostCalculator(decimal costPerCredit = 200000m)
    {
        _costPerCredit = costPerCredit;
    }

    public decimal CalculateTotalCost(List<ICourse> courses)
    {
        if (courses == null || courses.Count == 0)
            return 0;

        int totalCredits = courses.Sum(c => c.Credits);
        return totalCredits * _costPerCredit;
    }
}