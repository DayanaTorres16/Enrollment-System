using System;
using System.Collections.Generic;
using Ejercicio1.Miembros;
using Ejercicio1.Matricula;

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

        List<Person> people = new List<Person>
        {
            coordinator,
            secretary,
            student1,
            student2
        };

        Console.WriteLine("SHOWING INFORMATION OF ALL PERSONS\n");
        foreach (Person person in people)
        {
            person.ShowInformation();
        }

        Console.WriteLine("\n\nENROLLMENT PROCESS\n");

        Enrollment enrollment1 = new Enrollment
        {
            EnrollmentId = 1001,
            Student = student1,
            TotalCost = 2500000m,
            Responsible = coordinator
        };

        enrollment1.Courses.Add(new Course { Code = "POO101", Name = "Object-Oriented Programming", Credits = 4 });
        enrollment1.Courses.Add(new Course { Code = "BDA202", Name = "Advanced Databases", Credits = 3 });
        enrollment1.Courses.Add(new Course { Code = "EDT303", Name = "Data Structures", Credits = 3 });
        enrollment1.Courses.Add(new Course { Code = "ISO404", Name = "Software Engineering", Credits = 4 });

        enrollment1.RegisterEnrollment();
        enrollment1.MakePayment(1000000m);
        enrollment1.MakePayment(1500000m);
        EnrollmentReporter.ShowEnrollmentDetails(enrollment1);

        Console.WriteLine("\n\nSECOND ENROLLMENT\n");
        Enrollment enrollment2 = new Enrollment
        {
            EnrollmentId = 1002,
            Student = student2,
            TotalCost = 2200000m,
            Responsible = secretary
        };

        enrollment2.Courses.Add(new Course { Code = "MKT101", Name = "Digital Marketing", Credits = 3 });
        enrollment2.Courses.Add(new Course { Code = "FIN202", Name = "Corporate Finance", Credits = 4 });
        enrollment2.Courses.Add(new Course { Code = "GPR303", Name = "Project Management", Credits = 3 });

        enrollment2.RegisterEnrollment();
        enrollment2.MakePayment(2200000m);
        EnrollmentReporter.ShowEnrollmentDetails(enrollment2);

        Console.WriteLine("\n\nCANCELLATION TEST\n");
        enrollment2.CancelEnrollment();
        EnrollmentReporter.ShowEnrollmentDetails(enrollment2);
    }
}
