namespace Ejercicio1.Interfaces;

public interface IEnrollmentValidator
{
    bool ValidateEnrollment(IEnrollable enrollment, out string errorMessage);
}