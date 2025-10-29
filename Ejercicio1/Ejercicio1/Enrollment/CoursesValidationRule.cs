namespace Ejercicio1.Enrollment;

public class CoursesValidationRule : IValidationRule
{
    public string ValidationMessage => "The enrollment must have at least one course.";

    public bool Validate(Enrollment enrollment)
    {
        return enrollment.Courses != null && enrollment.Courses.Count > 0;
    }
}