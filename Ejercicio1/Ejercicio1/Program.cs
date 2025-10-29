using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
using Ejercicio1.Members;
using Ejercicio1.Enrollment;

class Program
{
    static void Main()
    {
        Console.WriteLine("UNIVERSITY ENROLLMENT SYSTEM (WITH OPEN/CLOSED PRINCIPLE)\n");

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
        staffReporter.ShowDetails(coordinator);
        staffReporter.ShowDetails(secretary);

        StudentReporter studentReporter = new StudentReporter();
        studentReporter.ShowDetails(student1);
        studentReporter.ShowDetails(student2);

        Console.WriteLine("\n\nENROLLMENT 1: STANDARD COST CALCULATION\n");
        
        var validator1 = new EnrollmentValidator();
        validator1.AddValidationRule(new StudentValidationRule());
        validator1.AddValidationRule(new CoursesValidationRule());
        validator1.AddValidationRule(new MaxCreditsValidationRule(20));
        
        var paymentProcessor1 = new FullPaymentProcessor();
        var payment1 = new Payment(paymentProcessor1);
        
        var enrollment1 = new Enrollment(
            new StandardCostCalculator(200000m),
            paymentProcessor1,
            payment1,
            validator1
        );

        enrollment1.EnrollmentId = 1001;
        enrollment1.Student = student1;
        enrollment1.Courses.Add(new Course { Code = "POO101", Name = "Object-Oriented Programming", Credits = 4 });
        enrollment1.Courses.Add(new Course { Code = "BDA202", Name = "Advanced Databases", Credits = 3 });
        enrollment1.Courses.Add(new Course { Code = "EDT303", Name = "Data Structures", Credits = 3 });
        enrollment1.Courses.Add(new Course { Code = "ISO404", Name = "Software Engineering", Credits = 4 });

        enrollment1.RegisterEnrollment();
        enrollment1.MakePayment(1000000m);
        enrollment1.MakePayment(1800000m);

        EnrollmentReporter enrollmentReporter = new EnrollmentReporter();
        enrollmentReporter.ShowDetails(enrollment1);

        Console.WriteLine("\nENROLLMENT 2: DISCOUNTED COST (20% OFF)\n");
        
        var validator2 = new EnrollmentValidator();
        validator2.AddValidationRule(new StudentValidationRule());
        validator2.AddValidationRule(new CoursesValidationRule());

        var paymentProcessor2 = new FullPaymentProcessor();
        var payment2 = new Payment(paymentProcessor2);

        var enrollment2 = new Enrollment(
            new DiscountedCostCalculator(200000m, 20m),
            paymentProcessor2,
            payment2,
            validator2
        );

        enrollment2.EnrollmentId = 1002;
        enrollment2.Student = student2;
        enrollment2.Courses.Add(new Course { Code = "MKT101", Name = "Digital Marketing", Credits = 3 });
        enrollment2.Courses.Add(new Course { Code = "FIN202", Name = "Corporate Finance", Credits = 4 });
        enrollment2.Courses.Add(new Course { Code = "GPR303", Name = "Project Management", Credits = 3 });

        enrollment2.RegisterEnrollment();
        enrollment2.MakePayment(enrollment2.TotalCost);

        enrollmentReporter.ShowDetails(enrollment2);
        
        Console.WriteLine("\nENROLLMENT 3: TIERED PRICING (VOLUME DISCOUNT)\n");

        Student student3 = new Student("Pedro", "Lopez", 5555555)
        {
            Email = "pedro.lopez@university.edu",
            PhoneNumber = "+57 305 5555555",
            Career = "Computer Science",
            Semester = 4
        };
        
        var validator3 = new EnrollmentValidator();
        validator3.AddValidationRule(new StudentValidationRule());
        validator3.AddValidationRule(new CoursesValidationRule());
        validator3.AddValidationRule(new SemesterProgressionValidationRule());

        var paymentProcessor3 = new PartialPaymentProcessor(30m);
        var payment3 = new Payment(paymentProcessor3);

        var enrollment3 = new Enrollment(
            new TieredCostCalculator(200000m),
            paymentProcessor3,
            payment3,
            validator3
        );

        enrollment3.EnrollmentId = 1003;
        enrollment3.Student = student3;
        enrollment3.Courses.Add(new Course { Code = "ALG101", Name = "Algorithms", Credits = 4 });
        enrollment3.Courses.Add(new Course { Code = "NET202", Name = "Networks", Credits = 4 });
        enrollment3.Courses.Add(new Course { Code = "AI303", Name = "Artificial Intelligence", Credits = 4 });
        enrollment3.Courses.Add(new Course { Code = "ML404", Name = "Machine Learning", Credits = 3 });

        enrollment3.RegisterEnrollment();
        enrollment3.MakePayment(1000000m);

        enrollmentReporter.ShowDetails(enrollment3);
        
        Console.WriteLine("\nCANCELLATION TEST\n");
        enrollment2.CancelEnrollment();
        enrollmentReporter.ShowDetails(enrollment2);

        Console.WriteLine("\nSUMMARY");
        Console.WriteLine($"Total enrollments processed: 3");
        Console.WriteLine($"Active enrollments: 2");
        Console.WriteLine($"Canceled enrollments: 1");
    }
}