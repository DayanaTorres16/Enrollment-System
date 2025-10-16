namespace Ejercicio1.Abstracciones;

public interface IPayable
{
    decimal CalculatePendingAmount();
    void MakePayment(decimal monto);
    bool IsFullyPaid();
}