using System.Collections.Generic;
using System.Linq;
using Ejercicio1.Interfaces;
using Ejercicio1.Enrollment;
namespace Ejercicio1.Factory;

public class CostCalculatorSelector : ICostCalculator
{
    private readonly StandardCostCalculator _standardCalculator;
    private readonly TieredCostCalculator _tieredCalculator;
    private readonly DiscountedCostCalculator _discountedCalculator;

    public CostCalculatorSelector(
        StandardCostCalculator standardCalculator,
        TieredCostCalculator tieredCalculator,
        DiscountedCostCalculator discountedCalculator)
    {
        _standardCalculator = standardCalculator;
        _tieredCalculator = tieredCalculator;
        _discountedCalculator = discountedCalculator;
    }

    public decimal CalculateTotalCost(List<ICourse> courses)
    {
        if (courses == null || courses.Count == 0)
        {
            return 0;
        }

        int totalCredits = courses.Sum(c => c.Credits);
        ICostCalculator selectedCalculator;

        if (totalCredits <= 12)
        {
            selectedCalculator = _standardCalculator;
        }
        else if (totalCredits > 12 && totalCredits <= 16)
        {
            selectedCalculator = _tieredCalculator;
        }
        else 
        {
            selectedCalculator = _discountedCalculator;
        }
        
        return selectedCalculator.CalculateTotalCost(courses);
    }
}