using System;
using Ejercicio1.Interfaces;
using Ejercicio1.Enum;
namespace Ejercicio1.Members;

public class Student : Person, IStudent
{
    public string Career { get; set; }
    public int Semester { get; set; }
    public string StudentCode { get; set; }
    public StudentType Type { get; set; }

    public Student(string name, string lastName, int documentNumber, StudentType type = StudentType.InPerson)
        : base(name, lastName, documentNumber)
    {
        StudentCode = $"EST{documentNumber}";
        Type = type;
    }

    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }

    public string GetStudentTypeDescription()
    {
        return Type switch
        {
            StudentType.Virtual => "Virtual Student",
            StudentType.InPerson => "In-Person Student",
            StudentType.Distance => "Distance Learning Student",
            StudentType.Exchange => "Exchange Student",
            _ => "Unknown"
        };
    }
}