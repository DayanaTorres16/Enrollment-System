using Ejercicio1.Enrollment;
using Ejercicio1.Interfaces;

namespace Ejercicio1.EnrollmentRules;

public class StudentValidationRule : IValidationRule
{
    public string ValidationMessage => "The enrollment must have a valid student.";

    public bool Validate(IEnrollment enrollment)
    {
        return enrollment.Student != null;
    }
}