using Ejercicio1.Interfaces;

namespace Ejercicio1.Enrollment;

public interface IValidationRule
{
    bool Validate(IEnrollable enrollment);
    string ValidationMessage { get; }
}