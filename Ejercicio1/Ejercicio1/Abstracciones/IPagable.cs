namespace Ejercicio1.Abstracciones;

public interface IPagable
{
    decimal CalcularMontoPendiente();
    void RealizarPago(decimal monto);
    bool EsPagadoCompleto();
}