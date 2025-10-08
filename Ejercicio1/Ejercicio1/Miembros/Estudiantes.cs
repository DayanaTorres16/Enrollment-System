using Ejercicio1.Abstracciones;
namespace Ejercicio1.Miembros;

public class Estudiante : Persona, IEstudiantes
{
    public string Carrera { get; set; }
    public int Semestre { get; set; }
    public string CodigoEstudiante { get; set; }
    
    public Estudiante(string nombre, string apellido, int documento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Documento = documento;
        CodigoEstudiante = $"EST{documento}";
    }
    
    public override void MostrarInformacion()
    {
        Console.WriteLine("\nINFORMACION DEL ESTUDIANTE");
        Console.WriteLine($"Codigo: {CodigoEstudiante}");
        Console.WriteLine($"Nombre: {ObtenerNombre()}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Telefono: {Telefono}");
        Console.WriteLine($"Carrera: {Carrera}");
        Console.WriteLine($"Semestre: {Semestre}");
    }
}