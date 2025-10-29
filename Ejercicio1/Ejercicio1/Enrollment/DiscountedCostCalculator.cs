using System;
using System.Collections.Generic;
using System.Linq;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class DiscountedCostCalculator : ICostCalculator
{
    private readonly decimal _costPerCredit;
    private readonly decimal _discountPercentage;
    public DiscountedCostCalculator(decimal costPerCredit, decimal discountPercentage) 
    { 
        _costPerCredit = costPerCredit; 
        _discountPercentage = discountPercentage;
    }
    public decimal CalculateTotalCost(List<ICourse> courses) 
    { 
        if (courses == null || courses.Count == 0) 
            return 0;

        int totalCredits = courses.Sum(c => c.Credits); 
        decimal baseCost = totalCredits * _costPerCredit; 
        decimal discount = baseCost * (_discountPercentage / 100); 
        return baseCost - discount;
    } 
}
