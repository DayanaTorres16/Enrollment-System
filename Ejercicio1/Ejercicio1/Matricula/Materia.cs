using Ejercicio1.Abstracciones;
namespace Ejercicio1.Matricula;
public class Course : ICourse
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }
}