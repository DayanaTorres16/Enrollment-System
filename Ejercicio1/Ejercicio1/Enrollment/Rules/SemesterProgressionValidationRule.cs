using Ejercicio1.Enrollment;
using Ejercicio1.Interfaces;

namespace Ejercicio1.EnrollmentRules;

public class SemesterProgressionValidationRule : IValidationRule
{
    public string ValidationMessage => "Student must be in semester 1 or higher.";

    public bool Validate(IEnrollment enrollment)
    {
        return enrollment.Student.Semester >= 1;
    }
}