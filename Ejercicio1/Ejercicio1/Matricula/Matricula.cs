using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;

public class Matricula : IMatriculable, IPagable
{
    public int IdMatricula { get; set; }
    public DateTime FechaMatricula { get; set; }
    public string Estado { get; private set; }
    public decimal CostoTotal { get; set; }
    public decimal MontoPagado { get; private set; }
    public IEstudiantes Estudiante { get; set; }

    public List<IMateria> Materias { get; set; } 
    
    public IResponsable ResponsableRegistro { get; set; }

    public Matricula()
    {
        Materias = new List<IMateria>();
        Estado = "Pendiente";
        MontoPagado = 0;
    }

    public void RegistrarMatricula()
    {
        if (ValidarMatricula())
        {
            Estado = "Activa";
            FechaMatricula = DateTime.Now;
            Console.WriteLine($"\nMatricula #{IdMatricula} registrada exitosamente");
            Console.WriteLine($"Estudiante: {Estudiante.ObtenerNombre()}");
            Console.WriteLine($"Registrada por: {ResponsableRegistro?.ObtenerNombre() ?? "Sistema"}");
        }
        else
        {
            Console.WriteLine($"\nError: No se pudo registrar la matricula #{IdMatricula}");
        }
    }

    public void CancelarMatricula()
    {
        if (Estado == "Activa")
        {
            Estado = "Cancelada";
            Console.WriteLine($"\nMatricula #{IdMatricula} ha sido cancelada");
        }
        else
        {
            Console.WriteLine($"\nNo se puede cancelar. Estado actual: {Estado}");
        }
    }

    public void MostrarDetallesMatricula()
    {
        Console.WriteLine("\nDETALLE DE MATRICULA");
        Console.WriteLine($"ID Matricula: #{IdMatricula}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine($"Fecha: {FechaMatricula:dd/MM/yyyy}");
        Console.WriteLine($"\nEstudiante:");
        Console.WriteLine($"Nombre: {Estudiante.ObtenerNombre()}");
        Console.WriteLine($"Codigo: {Estudiante.CodigoEstudiante}");
        Console.WriteLine($"Carrera: {Estudiante.Carrera}");
        Console.WriteLine($"Semestre: {Estudiante.Semestre}");
        Console.WriteLine($"\nInformacion Financiera:");
        Console.WriteLine($"Costo Total: ${CostoTotal:N2}");
        Console.WriteLine($"Monto Pagado: ${MontoPagado:N2}");
        Console.WriteLine($"Monto Pendiente: ${CalcularMontoPendiente():N2}");
        Console.WriteLine($"Estado de Pago: {(EsPagadoCompleto() ? "COMPLETO" : "PENDIENTE")}");
        Console.WriteLine($"\nMaterias Inscritas ({Materias.Count}):");
        foreach (var materia in Materias)
        {
            Console.WriteLine($"  - {materia.Nombre} ({materia.Creditos} Creditos)");
        }
        if (ResponsableRegistro != null)
        {
            Console.WriteLine($"\nRegistrada por: {ResponsableRegistro.ObtenerNombre()} ({ResponsableRegistro.Cargo})");
        }
    }

    public decimal CalcularMontoPendiente()
    {
        return CostoTotal - MontoPagado;
    }

    public void RealizarPago(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("\nEl monto debe ser mayor a 0");
            return;
        }

        if (monto > CalcularMontoPendiente())
        {
            Console.WriteLine($"\nEl monto excede la deuda. Pendiente: ${CalcularMontoPendiente():N2}");
            return;
        }

        MontoPagado += monto;
        Console.WriteLine($"\nPago registrado: ${monto:N2}");
        Console.WriteLine($"Total pagado: ${MontoPagado:N2}");
        Console.WriteLine($"Pendiente: ${CalcularMontoPendiente():N2}");
    }

    public bool EsPagadoCompleto()
    {
        return MontoPagado >= CostoTotal;
    }

    private bool ValidarMatricula()
    {
        return Estudiante != null && 
               Materias.Count > 0 && 
               CostoTotal > 0 &&
               ResponsableRegistro != null;
    }
}