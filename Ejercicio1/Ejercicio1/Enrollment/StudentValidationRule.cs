using Ejercicio1.Interfaces;

namespace Ejercicio1.Enrollment;

public class StudentValidationRule : IValidationRule
{
    public string ValidationMessage => "The enrollment must have a valid student.";

    public bool Validate(IEnrollable enrollment)
    {
        return enrollment.Student != null;
    }
}