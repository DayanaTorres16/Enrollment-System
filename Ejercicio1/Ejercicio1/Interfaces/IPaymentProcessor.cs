using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount, IPayment payment);
    string PaymentType { get; }
    bool CanProcessPayment(decimal amount, IPayment payment, out string errorMessage);
}