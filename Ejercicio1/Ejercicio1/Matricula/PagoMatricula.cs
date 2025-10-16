using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;


public class PagoMatricula:IPagable
{
    public decimal CostoTotal { get; set; }
    public decimal MontoPagado { get; set; }
    
    public decimal CalcularMontoPendiente()
    {
        return CostoTotal - MontoPagado;
    }

    public void RealizarPago(decimal monto)
    {
        if (monto <= 0)
        {
            throw new Exception("El monto debe ser mayor a 0");
        }

        if (monto > CalcularMontoPendiente())
        {
            throw new Exception("El monto excede la deuda.");
        }
        MontoPagado += monto;
    }

    public bool EsPagadoCompleto()
    {
        return MontoPagado >= CostoTotal;
    }
};