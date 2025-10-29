namespace Ejercicio1.Enrollment;

public interface IValidationRule
{
    bool Validate(Enrollment enrollment);
    string ValidationMessage { get; }
}