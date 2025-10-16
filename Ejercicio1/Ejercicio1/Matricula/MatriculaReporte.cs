
namespace Ejercicio1.Matricula;

public class MatriculaReporte
{
    public static void MostrarDetallesMatricula(Matricula matricula)
    {
        Console.WriteLine("\nDETALLE DE MATRICULA");
        Console.WriteLine($"ID Matricula: #{matricula.IdMatricula}");
        Console.WriteLine($"Estado: {matricula.Estado}");
        Console.WriteLine($"Fecha: {matricula.FechaMatricula:dd/MM/yyyy}");
        Console.WriteLine($"\nEstudiante:");
        Console.WriteLine($"Nombre: {matricula.Estudiante.ObtenerNombre()}");
        Console.WriteLine($"Codigo: {matricula.Estudiante.CodigoEstudiante}");
        Console.WriteLine($"Carrera: {matricula.Estudiante.Carrera}");
        Console.WriteLine($"Semestre: {matricula.Estudiante.Semestre}");
        Console.WriteLine($"\nInformacion Financiera:");
        Console.WriteLine($"Costo Total: ${matricula.CostoTotal:N2}");
        Console.WriteLine($"Monto Pagado: ${matricula.pago.MontoPagado:N2}");
        Console.WriteLine($"Monto Pendiente: ${matricula.CalcularMontoPendiente():N2}");
        Console.WriteLine($"Estado de Pago: {(matricula.EsPagadoCompleto() ? "COMPLETO" : "PENDIENTE")}");
        Console.WriteLine($"\nMaterias Inscritas ({matricula.Materias.Count}):");
        foreach (var materia in matricula.Materias)
        {
            Console.WriteLine($"  - {materia.Nombre} ({materia.Creditos} Creditos)");
        }
        if (matricula.ResponsableRegistro != null)
        {
            Console.WriteLine($"\nRegistrada por: {matricula.ResponsableRegistro.ObtenerNombre()} ({matricula.ResponsableRegistro.Cargo})");
        }
    }
}