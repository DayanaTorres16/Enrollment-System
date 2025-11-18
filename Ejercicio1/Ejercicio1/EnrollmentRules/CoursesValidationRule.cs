using Ejercicio1.Enrollment;
using Ejercicio1.Interfaces;

namespace Ejercicio1.EnrollmentRules;

public class CoursesValidationRule : IValidationRule
{
    public string ValidationMessage => "The enrollment must have at least one course.";

    public bool Validate(IEnrollment enrollment)
    {
        return enrollment.Courses != null && enrollment.Courses.Count > 0;
    }
}