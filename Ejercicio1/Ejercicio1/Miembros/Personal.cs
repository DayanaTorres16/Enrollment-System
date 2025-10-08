using Ejercicio1.Abstracciones;
namespace Ejercicio1.Miembros;

public class Personal : Persona, IResponsable
{
    public string Cargo { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public string CodigoEmpleado { get; set; }

    public Personal(string nombre, string apellido, int documento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Documento = documento;
        CodigoEmpleado = $"PER{documento}";
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("\nINFORMACION DEL PERSONAL");
        Console.WriteLine($"Codigo: {CodigoEmpleado}");
        Console.WriteLine($"Nombre: {ObtenerNombre()}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Telefono: {Telefono}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Departamento: {Departamento}");
        Console.WriteLine($"Salario: ${Salario:N2}");
    }
}