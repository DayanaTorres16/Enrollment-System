namespace Ejercicio1.Enrollment;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount, Payment payment);
    string PaymentType { get; }
    bool CanProcessPayment(decimal amount, Payment payment, out string errorMessage);
}