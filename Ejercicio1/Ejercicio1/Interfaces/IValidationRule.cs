using Ejercicio1.Interfaces;

namespace Ejercicio1.Enrollment;

public interface IValidationRule
{
    bool Validate(IEnrollment enrollment);
    string ValidationMessage { get; }
}