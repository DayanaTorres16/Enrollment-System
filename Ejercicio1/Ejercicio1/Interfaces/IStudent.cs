using Ejercicio1.Enum;

namespace Ejercicio1.Interfaces;

public interface IStudent
{
    string StudentCode { get; }
    string Career { get; }
    int Semester { get; }
    StudentType Type { get; }
    string GetFullName();
}