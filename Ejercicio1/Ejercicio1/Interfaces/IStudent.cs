namespace Ejercicio1.Interfaces;

public interface IStudent
{
    string StudentCode { get; }
    string Career { get; }
    int Semester { get; }
    string GetFullName();
}