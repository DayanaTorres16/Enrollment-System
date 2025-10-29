namespace Ejercicio1.Enrollment;

public class SemesterProgressionValidationRule : IValidationRule
{
    public string ValidationMessage => "Student must be in semester 1 or higher.";

    public bool Validate(Enrollment enrollment)
    {
        return enrollment.Student.Semester >= 1;
    }
}