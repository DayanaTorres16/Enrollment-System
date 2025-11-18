using System.Linq;
using Ejercicio1.Enrollment;
using Ejercicio1.Interfaces;

namespace Ejercicio1.EnrollmentRules;

public class MaxCreditsValidationRule : IValidationRule
{
    private readonly int _maxCredits;

    public MaxCreditsValidationRule(int maxCredits = 20)
    {
        _maxCredits = maxCredits;
    }

    public string ValidationMessage => $"The enrollment cannot exceed {_maxCredits} credits.";

    public bool Validate(IEnrollment enrollment)
    {
        int totalCredits = enrollment.Courses.Sum(c => c.Credits);
        return totalCredits <= _maxCredits;
    }
}