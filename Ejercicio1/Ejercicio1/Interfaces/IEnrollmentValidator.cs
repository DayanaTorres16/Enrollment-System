namespace Ejercicio1.Interfaces;

public interface IEnrollmentValidator
{
    bool ValidateEnrollment(IEnrollment enrollment, out string errorMessage);
}