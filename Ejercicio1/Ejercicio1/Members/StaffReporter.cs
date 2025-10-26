using System;
namespace Ejercicio1.Members;

public class StaffReporter
{
    public void ShowStaffDetails(Staff staff)
    {
        Console.WriteLine("\nSTAFF INFORMATION");
        Console.WriteLine($"Code: {staff.EmployeeCode}");
        Console.WriteLine($"Name: {staff.GetFullName()}");
        Console.WriteLine($"Document Number: {staff.GetDocumentNumber()}");
        Console.WriteLine($"Email: {staff.Email}");
        Console.WriteLine($"Phone Number: {staff.PhoneNumber}");
        Console.WriteLine($"Position: {staff.Position}");
        Console.WriteLine($"Department: {staff.Department}");
        Console.WriteLine($"Salary: ${staff.Salary:N2}");
    }
}