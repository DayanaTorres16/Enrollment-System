using Ejercicio1.Interfaces;

namespace Ejercicio1.Enrollment;

public class CoursesValidationRule : IValidationRule
{
    public string ValidationMessage => "The enrollment must have at least one course.";

    public bool Validate(IEnrollable enrollment)
    {
        return enrollment.Courses != null && enrollment.Courses.Count > 0;
    }
}