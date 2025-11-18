using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public abstract class Person
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int DocumentNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    protected Person(string name, string lastName, int documentNumber)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException("Name and last name cannot be empty");
        }
        if (documentNumber < 0)
        {
            throw new ArgumentException("Document number cannot be negative");
        }
        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
    }
    public int GetDocumentNumber()
    {
        return DocumentNumber;
    }
}