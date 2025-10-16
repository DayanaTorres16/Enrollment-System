using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;


public class Payment : IPayable
{
    public decimal TotalCost  { get; set; }
    public decimal AmountPaid  { get; set; }
    
    public decimal CalculatePendingAmount()
    {
        return TotalCost - AmountPaid;
    }

    public void MakePayment(decimal amount)

    {
        if (amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than 0");
        }
        if (amount > CalculatePendingAmount())
        {
            throw new InvalidOperationException("The amount exceeds the debt.");
        }
        AmountPaid += amount;
    }
    public bool IsFullyPaid()
    {
        return AmountPaid >= TotalCost;
    }
};