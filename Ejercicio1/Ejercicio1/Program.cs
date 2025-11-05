using System;
using System.Collections.Generic;
using Ejercicio1.Interfaces;
using Ejercicio1.Members;
using Ejercicio1.Enrollment;
using Ejercicio1.Enum;

class Program
{
    static void Main()
    {
        Console.WriteLine("UNIVERSITY ENROLLMENT SYSTEM WITH STUDENT TYPES\n");
        
        Staff coordinator = new Staff("Carlos", "Rodriguez", 9876543)
        {
            Email = "carlos.rodriguez@university.edu",
            PhoneNumber = "+57 320 9876543",
            Position = "Academic Coordinator",
            Department = "Faculty of Engineering",
            Salary = 4500000m
        };
        
        Student student1 = new Student("Juan", "Perez", 1234567, StudentType.InPerson)
        {
            Email = "juan.perez@university.edu",
            PhoneNumber = "+57 300 1234567",
            Career = "Systems Engineering",
            Semester = 5
        };

        Student student2 = new Student("Maria", "Garcia", 7654321, StudentType.Virtual)
        {
            Email = "maria.garcia@university.edu",
            PhoneNumber = "+57 310 7654321",
            Career = "Business Administration",
            Semester = 3
        };

        Student student3 = new Student("Pedro", "Lopez", 5555555, StudentType.Distance)
        {
            Email = "pedro.lopez@university.edu",
            PhoneNumber = "+57 305 5555555",
            Career = "Computer Science",
            Semester = 4
        };

        Student student4 = new Student("Sofia", "Martinez", 8888888, StudentType.Exchange)
        {
            Email = "sofia.martinez@university.edu",
            PhoneNumber = "+57 315 8888888",
            Career = "International Relations",
            Semester = 6
        };

        Console.WriteLine("SHOWING STUDENT INFORMATION WITH TYPES\n");

        StudentReporter studentReporter = new StudentReporter();
        studentReporter.ShowDetails(student1);
        studentReporter.ShowDetails(student2);
        studentReporter.ShowDetails(student3);
        studentReporter.ShowDetails(student4);

        Console.WriteLine("\n\nENROLLMENT 1: IN-PERSON STUDENT\n");

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

        Console.WriteLine("\nENROLLMENT 2: VIRTUAL STUDENT WITH DISCOUNT\n");

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

        Console.WriteLine("\nENROLLMENT 3: EXCHANGE STUDENT\n");

        var validator3 = new EnrollmentValidator();
        validator3.AddValidationRule(new StudentValidationRule());
        validator3.AddValidationRule(new CoursesValidationRule());

        var paymentProcessor3 = new PartialPaymentProcessor(30m);
        var payment3 = new Payment(paymentProcessor3);

        var enrollment3 = new Enrollment(
            new TieredCostCalculator(200000m),
            paymentProcessor3,
            payment3,
            validator3
        );

        enrollment3.EnrollmentId = 1003;
        enrollment3.Student = student4;
        enrollment3.Courses.Add(new Course { Code = "INT101", Name = "International Politics", Credits = 4 });
        enrollment3.Courses.Add(new Course { Code = "ECO202", Name = "Global Economics", Credits = 4 });

        enrollment3.RegisterEnrollment();
        enrollment3.MakePayment(600000m);

        enrollmentReporter.ShowDetails(enrollment3);

        Console.WriteLine("\nSUMMARY");
        Console.WriteLine($"Total enrollments processed: 3");
        Console.WriteLine($"In-Person Students: 1");
        Console.WriteLine($"Virtual Students: 1");
        Console.WriteLine($"Exchange Students: 1");
    }
}