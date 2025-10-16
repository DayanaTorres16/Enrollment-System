namespace Ejercicio1.Abstracciones;

public interface IStudent
{
    string StudentCode { get; }
    string Career { get; }
    int Semester { get; }
    string GetFullName();
}