using System;
namespace Ejercicio1.Members;

public static class PersonalReport
{
    public static void ShowPersonalDetails(Personal personal)
    {
        Console.WriteLine("\nSTAFF INFORMATION");
        Console.WriteLine($"Code: {personal.EmployeeCode}");
        Console.WriteLine($"Name: {personal.GetFullName()}");
        Console.WriteLine($"Document Number: {personal.GetDocumentNumber()}");
        Console.WriteLine($"Email: {personal.Email}");
        Console.WriteLine($"Phone Number: {personal.PhoneNumber}");
        Console.WriteLine($"Position: {personal.Position}");
        Console.WriteLine($"Department: {personal.Department}");
        Console.WriteLine($"Salary: ${personal.Salary:N2}");
    }
}