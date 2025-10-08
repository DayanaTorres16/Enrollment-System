namespace Ejercicio1.Abstracciones;

public interface IEstudiantes
{
    string CodigoEstudiante { get; }
    string Carrera { get; }
    int Semestre { get; }
    string ObtenerNombre();
}

public interface IResponsable
{
    string ObtenerNombre();
    string Cargo { get; }
}

public interface IMatriculable
{
    void RegistrarMatricula();
    void CancelarMatricula();
    void MostrarDetallesMatricula();
}

public interface IPagable
{
    decimal CalcularMontoPendiente();
    void RealizarPago(decimal monto);
    bool EsPagadoCompleto();
}

public interface IMateria
{
    string Codigo { get; }
    string Nombre { get; }
    int Creditos { get; }
}