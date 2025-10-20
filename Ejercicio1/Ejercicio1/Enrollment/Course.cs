using Ejercicio1.Interfaces;
namespace Ejercicio1.Enrollment;
public class Course : ICourse
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }
}