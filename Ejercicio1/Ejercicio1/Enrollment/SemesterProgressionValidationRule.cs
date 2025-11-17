using Ejercicio1.Interfaces;

namespace Ejercicio1.Enrollment;

public class SemesterProgressionValidationRule : IValidationRule
{
    public string ValidationMessage => "Student must be in semester 1 or higher.";

    public bool Validate(IEnrollable enrollment)
    {
        return enrollment.Student.Semester >= 1;
    }
}