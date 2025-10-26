namespace Ejercicio1.Interfaces;

public interface IPayable
{
    decimal TotalCost  { get; }
    decimal AmountPaid  { get; }
    decimal CalculatePendingAmount();
    void MakePayment(decimal amount);
    bool IsFullyPaid();
}