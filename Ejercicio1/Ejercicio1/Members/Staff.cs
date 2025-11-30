using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public class Staff : IPerson, IStaff
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int DocumentNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Position { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public string EmployeeCode { get; set; }

    public Staff(string name, string lastName, int documentNumber)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Name and last name cannot be empty");

        if (documentNumber < 0)
            throw new ArgumentException("Document number cannot be negative");

        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
        EmployeeCode = $"STAFF{documentNumber}";
    }

    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }

    public int GetDocumentNumber()
    {
        return DocumentNumber;
    }
}