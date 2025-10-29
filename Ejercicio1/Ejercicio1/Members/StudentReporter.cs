using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public class StudentReporter : IReporter<Student>
{
    public void ShowDetails(Student student)
    {
        Console.WriteLine("\nSTUDENT INFORMATION");
        Console.WriteLine($"Code: {student.StudentCode}");
        Console.WriteLine($"Name: {student.GetFullName()}");
        Console.WriteLine($"Document Number: {student.GetDocumentNumber()}");
        Console.WriteLine($"Email: {student.Email}");
        Console.WriteLine($"Phone Number: {student.PhoneNumber}");
        Console.WriteLine($"Career: {student.Career}");
        Console.WriteLine($"Semester: {student.Semester}");
    }
}