using System;
using Ejercicio1.Interfaces;
using Ejercicio1.Enum;
namespace Ejercicio1.Members;

public class Student : IPerson, IStudent
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int DocumentNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Career { get; set; }
    public int Semester { get; set; }
    public string StudentCode { get; set; }
    public StudentType Type { get; set; }

    public Student(string name, string lastName, int documentNumber, StudentType type = StudentType.InPerson)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Name and last name cannot be empty");

        if (documentNumber < 0)
            throw new ArgumentException("Document number cannot be negative");

        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
        StudentCode = $"EST{documentNumber}";
        Type = type;
    }

    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }

    public int GetDocumentNumber()
    {
        return DocumentNumber;
    }

    public string GetStudentTypeDescription()
    {
        return Type switch
        {
            StudentType.Virtual => "Virtual Student",
            StudentType.InPerson => "In-Person Student",
            StudentType.Distance => "Distance Learning Student",
            StudentType.Exchange => "Exchange Student", _=> "Unknown"
        };
    }
}