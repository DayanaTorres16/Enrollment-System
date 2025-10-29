using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public class EnrollmentValidator
{
    private readonly List<IValidationRule> _validationRules;

    public EnrollmentValidator()
    {
        _validationRules = new List<IValidationRule>();
    }

    public void AddValidationRule(IValidationRule rule)
    {
        _validationRules.Add(rule);
    }

    public bool ValidateEnrollment(Enrollment enrollment, out string errorMessage)
    {
        foreach (var rule in _validationRules)
        {
            if (!rule.Validate(enrollment))
            {
                errorMessage = rule.ValidationMessage;
                return false;
            }
        }
        errorMessage = string.Empty;
        return true;
    }
}
