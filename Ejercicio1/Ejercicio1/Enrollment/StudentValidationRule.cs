namespace Ejercicio1.Enrollment;

public class StudentValidationRule : IValidationRule
{
    public string ValidationMessage => "The enrollment must have a valid student.";

    public bool Validate(Enrollment enrollment)
    {
        return enrollment.Student != null;
    }
}