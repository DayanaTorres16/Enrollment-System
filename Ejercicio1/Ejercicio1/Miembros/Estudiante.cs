using System;
using Ejercicio1.Abstracciones;
namespace Ejercicio1.Miembros;

public class Student : Person, IStudent
{
    public string Career { get; set; }
    public int Semester { get; set; }
    public string StudentCode { get; }
    
    public Student(string name, string lastName, int documentNumber)
    {
        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
        StudentCode = $"EST{documentNumber}";
    }

    public override void ShowInformation()
    {
        Console.WriteLine("\nSTUDENT INFORMATION");
        Console.WriteLine($"Code: {StudentCode}");
        Console.WriteLine($"Name: {GetFullName()}");
        Console.WriteLine($"Document Number: {DocumentNumber}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine($"Major: {Career}");
        Console.WriteLine($"Semester: {Semester}");
    }
}