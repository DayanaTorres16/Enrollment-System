namespace Ejercicio1.Interfaces;

public interface IPayable
{
    decimal TotalCost  { get; set; }
    decimal AmountPaid  { get; set; }
    decimal CalculatePendingAmount();
    void MakePayment(decimal monto);
    
    bool IsFullyPaid();
}