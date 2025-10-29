using System;
using System.Collections.Generic;
using System.Linq;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class TieredCostCalculator : ICostCalculator
{
    private readonly decimal _baseCostPerCredit;

    public TieredCostCalculator(decimal baseCostPerCredit = 200000m)
    {
        _baseCostPerCredit = baseCostPerCredit;
    }

    public decimal CalculateTotalCost(List<ICourse> courses)
    {
        if (courses == null || courses.Count == 0)
            return 0;

        int totalCredits = courses.Sum(c => c.Credits);
        
        if (totalCredits >= 15)
            return totalCredits * _baseCostPerCredit * 0.85m; 
        else if (totalCredits >= 12)
            return totalCredits * _baseCostPerCredit * 0.90m;
        else
            return totalCredits * _baseCostPerCredit;
    }
}