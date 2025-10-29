namespace Ejercicio1.Interfaces;

public interface IPayment
{
    decimal TotalCost  { get; set; }
    decimal AmountPaid  { get; }
    decimal CalculatePendingAmount();
    void MakePayment(decimal amount);
    bool IsFullyPaid();
}