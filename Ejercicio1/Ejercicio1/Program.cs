using System;
using System.Collections.Generic;
using Ejercicio1.Members;
using Ejercicio1.Enrollment;

class Program
{
    static void Main()
    {
        Console.WriteLine("UNIVERSITY ENROLLMENT SYSTEM\n");
        
        Staff coordinator = new Staff("Carlos", "Rodriguez", 9876543)
        {
            Email = "carlos.rodriguez@university.edu",
            PhoneNumber = "+57 320 9876543",
            Position = "Academic Coordinator",
            Department = "Faculty of Engineering",
            Salary = 4500000m
        };

        Staff secretary = new Staff("Ana", "Martinez", 3456789)
        {
            Email = "ana.martinez@university.edu",
            PhoneNumber = "+57 315 3456789",
            Position = "Academic Secretary",
            Department = "Registration and Control",
            Salary = 2800000m
        };
        
        Student student1 = new Student("Juan", "Perez", 1234567)
        {
            Email = "juan.perez@university.edu",
            PhoneNumber = "+57 300 1234567",
            Career = "Systems Engineering",
            Semester = 5
        };

        Student student2 = new Student("Maria", "Garcia", 7654321)
        {
            Email = "maria.garcia@university.edu",
            PhoneNumber = "+57 310 7654321",
            Career = "Business Administration",
            Semester = 3
        };
        
        Console.WriteLine("SHOWING INFORMATION OF ALL PERSONS\n");
        
        StaffReporter staffReporter = new StaffReporter();
        staffReporter.ShowStaffDetails(coordinator);
        staffReporter.ShowStaffDetails(secretary);

        StudentReporter studentReporter = new StudentReporter();
        studentReporter.ShowStudentDetails(student1);
        studentReporter.ShowStudentDetails(student2);
        
        Console.WriteLine("\n\nENROLLMENT PROCESS\n");

        Enrollment enrollment1 = new Enrollment()
        {
            EnrollmentId = 1001,
            Student = student1
        };

        enrollment1.Courses.Add(new Course { Code = "POO101", Name = "Object-Oriented Programming", Credits = 4 });
        enrollment1.Courses.Add(new Course { Code = "BDA202", Name = "Advanced Databases", Credits = 3 });
        enrollment1.Courses.Add(new Course { Code = "EDT303", Name = "Data Structures", Credits = 3 });
        enrollment1.Courses.Add(new Course { Code = "ISO404", Name = "Software Engineering", Credits = 4 });

        enrollment1.RegisterEnrollment();
        enrollment1.MakePayment(1000000m);
        enrollment1.MakePayment(1500000m);
        
        EnrollmentReporter enrollmentReporter = new EnrollmentReporter();
        enrollmentReporter.ShowEnrollmentDetails(enrollment1);

        Console.WriteLine("\n\nSECOND ENROLLMENT\n");
        
        Enrollment enrollment2 = new Enrollment()
        {
            EnrollmentId = 1002,
            Student = student2
        };

        enrollment2.Courses.Add(new Course { Code = "MKT101", Name = "Digital Marketing", Credits = 3 });
        enrollment2.Courses.Add(new Course { Code = "FIN202", Name = "Corporate Finance", Credits = 4 });
        enrollment2.Courses.Add(new Course { Code = "GPR303", Name = "Project Management", Credits = 3 });

        enrollment2.RegisterEnrollment();
        enrollment2.MakePayment(enrollment2.TotalCost);
        
        enrollmentReporter.ShowEnrollmentDetails(enrollment2);

        Console.WriteLine("\n\nCANCELLATION TEST\n");
        enrollment2.CancelEnrollment();
        enrollmentReporter.ShowEnrollmentDetails(enrollment2);
    }
}
