using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;

public class Matricula : IMatriculable
{
    public int IdMatricula { get; set; }
    public DateTime FechaMatricula { get; set; }
    public string Estado { get; private set; }
    public decimal CostoTotal { get; set; }
    public IEstudiantes Estudiante { get; set; }

    public List<IMateria> Materias { get; set; } 
    
    public IResponsable ResponsableRegistro { get; set; }
    public PagoMatricula pago;

    public Matricula()
    {
        Materias = new List<IMateria>();
        Estado = "Pendiente";
        pago = new PagoMatricula();
    }

    public void RegistrarMatricula()
    {
        if (ValidarMatricula())
        {
            Estado = "Activa";
            FechaMatricula = DateTime.Now;
            pago.CostoTotal = this.CostoTotal;
        }
        else
        {
            throw new Exception("No se puede registrar la matricula");
        }
    }

    public void CancelarMatricula()
    {
        if (Estado == "Activa")
        {
            Estado = "Cancelada";
        }
        else
        {
            throw new InvalidOperationException("No se puede cancelar.");
        }
    }
    public decimal CalcularMontoPendiente()
    {
        return pago.CalcularMontoPendiente();
    }
    public void RealizarPago(decimal monto)
    {
        pago.RealizarPago(monto);
    }
    public bool EsPagadoCompleto()
    {
        return pago.EsPagadoCompleto();
    }
    private bool ValidarMatricula()
    {
        return Estudiante != null && 
               Materias.Count > 0 && 
               CostoTotal > 0 && 
               ResponsableRegistro != null;
    }
}