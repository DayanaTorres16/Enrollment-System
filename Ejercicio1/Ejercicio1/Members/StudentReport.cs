using System;
namespace Ejercicio1.Members;

public class StudentReport
{
    public static void ShowStudentDetails (Student student)
    {
        Console.WriteLine("\nSTUDENT INFORMATION");
        Console.WriteLine($"Code: {student.StudentCode}");
        Console.WriteLine($"Name: {student.GetFullName()}");
        Console.WriteLine($"Document Number: {student.GetDocumentNumber()}");
        Console.WriteLine($"Email: {student.Email}");
        Console.WriteLine($"Phone Number: {student.PhoneNumber}");
        Console.WriteLine($"Major: {student.Career}");
        Console.WriteLine($"Semester: {student.Semester}");
    }
}