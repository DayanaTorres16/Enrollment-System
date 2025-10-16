using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;
public class Materia : IMateria
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int Creditos { get; set; }
}