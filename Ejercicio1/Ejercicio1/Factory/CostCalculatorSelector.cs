using System.Collections.Generic;
using System.Linq;
using Ejercicio1.Interfaces;
using Ejercicio1.Enrollment;
namespace Ejercicio1.Factory;

public class CostCalculatorSelector : ICostCalculatorFactory 
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
    
    public ICostCalculator CreateCalculator(List<ICourse> courses)
    {
        if (courses == null || courses.Count == 0)
        {
            return _standardCalculator; 
        }

        int totalCredits = courses.Sum(c => c.Credits);

        if (totalCredits <= 12)
        {
            return _standardCalculator;
        }
        else if (totalCredits > 12 && totalCredits <= 16)
        {
            return _tieredCalculator;
        }
        else 
        {
            return _discountedCalculator;
        }
    }
}