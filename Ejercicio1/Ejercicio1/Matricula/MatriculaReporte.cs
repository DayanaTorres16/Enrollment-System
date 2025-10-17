
using System;

namespace Ejercicio1.Matricula;

public static class EnrollmentReporter
{
    public static void ShowEnrollmentDetails(Enrollment enrollment)
    {
        Console.WriteLine("\nENROLLMENT DETAILS");
        Console.WriteLine($"Enrollment ID: #{enrollment.EnrollmentId}");
        Console.WriteLine($"Status: {enrollment.Status}");
        Console.WriteLine($"Date: {enrollment.EnrollmentDate:dd/MM/yyyy}");
        Console.WriteLine($"\nStudent:");
        Console.WriteLine($"Name: {enrollment.Student.GetFullName()}");
        Console.WriteLine($"Code: {enrollment.Student.StudentCode}");
        Console.WriteLine($"Major: {enrollment.Student.Career}");
        Console.WriteLine($"Semester: {enrollment.Student.Semester}");
        Console.WriteLine($"\nFinancial Information:");
        Console.WriteLine($"Total Cost: ${enrollment.TotalCost:N2}");
        Console.WriteLine($"Amount Paid: ${enrollment.payment.AmountPaid:N2}");
        Console.WriteLine($"Pending Amount: ${enrollment.CalculatePendingAmount():N2}");
        Console.WriteLine($"Payment Status: {(enrollment.IsFullyPaid() ? "FULLY PAID" : "PENDING")}");
        Console.WriteLine($"\nEnrolled Courses ({enrollment.Courses.Count}):");
        foreach (var course in enrollment.Courses)
        {
            Console.WriteLine($"  - {course.Name} ({course.Credits} Credits)");
        }
        if (enrollment.Responsible != null)
        {
            Console.WriteLine($"\nRegistered by: {enrollment.Responsible.GetFullName()} ({enrollment.Responsible.Position})");
        }
    }
}