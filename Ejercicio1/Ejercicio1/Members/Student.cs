using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public class Student : Person, IStudent
{
    public string Career { get; set; }
    public int Semester { get; set; }
    public string StudentCode { get; set; }
    
    public Student(string name, string lastName, int documentNumber)
        :base (name, lastName, documentNumber)
    {
        StudentCode = $"EST{documentNumber}";
    }
    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }
}