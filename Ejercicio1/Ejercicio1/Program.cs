using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ejercicio1.Interfaces;
using Ejercicio1.Members;
using Ejercicio1.Enrollment;
using Ejercicio1.EnrollmentRules;
using Ejercicio1.Enum;
using Ejercicio1.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IReporter<Student>, StudentReporter>();
builder.Services.AddSingleton<IReporter<Staff>, StaffReporter>();
builder.Services.AddSingleton<IReporter<Enrollment>, EnrollmentReporter>();

builder.Services.AddScoped<IEnrollmentValidator>(provider =>
{
    var validator = new EnrollmentValidator();
    validator.AddValidationRule(new StudentValidationRule());
    validator.AddValidationRule(new CoursesValidationRule());
    validator.AddValidationRule(new MaxCreditsValidationRule(20));
    validator.AddValidationRule(new SemesterProgressionValidationRule());
    return validator;
});

builder.Services.AddScoped<StandardCostCalculator>(provider =>
    new StandardCostCalculator(200000m));

builder.Services.AddScoped<DiscountedCostCalculator>(provider => 
    new DiscountedCostCalculator(200000m, 20m));

builder.Services.AddScoped<TieredCostCalculator>(provider => 
    new TieredCostCalculator(200000m));

builder.Services.AddScoped<ICostCalculatorFactory, CostCalculatorSelector>();

builder.Services.AddScoped<FullPaymentProcessor>();
builder.Services.AddScoped<PartialPaymentProcessor>(provider => 
    new PartialPaymentProcessor(30m));

builder.Services.AddScoped<IPaymentProcessor, PaymentProcessorSelector>();

builder.Services.AddScoped<Enrollment>();

builder.Services.AddScoped<IPayment>(provider =>
{
    var processor = provider.GetRequiredService<IPaymentProcessor>();
    return new Payment(processor);
});

builder.Services.AddSingleton<List<Student>>(sp =>
{
    return new List<Student>
    {
        new Student("Juan", "Perez", 1234567, StudentType.InPerson) { StudentCode = "EST1234567", Email = "juan.perez@uni.edu", Career = "Sistemas", Semester = 5 },
        new Student("Maria", "Garcia", 7654321, StudentType.Virtual) { StudentCode = "EST7654321", Email = "maria.garcia@uni.edu", Career = "Administración", Semester = 1 }
    };
});

builder.Services.AddSingleton<List<Course>>(sp =>
{
    return new List<Course>
    {
        new Course { Code = "POO101", Name = "Programación Orientada a Objetos", Credits = 4 },
        new Course { Code = "BDA202", Name = "Bases de Datos Avanzadas", Credits = 3 },
        new Course { Code = "MKT101", Name = "Marketing Digital", Credits = 3 },
        new Course { Code = "FIN202", Name = "Finanzas Corporativas", Credits = 4 }
    };
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/api/students", (List<Student> students) =>
{
    if (students == null || students.Count == 0)
    {
        return Results.NotFound("No students found.");
    }
    return Results.Ok(students);
});

app.MapGet("/api/coordinator", () =>
{
    var coordinator = new Staff("Carlos", "Rodriguez", 9876543)
    {
        Email = "carlos.rodriguez@university.edu",
        PhoneNumber = "+57 320 9876543",
        Position = "Academic Coordinator",
        Department = "Faculty of Engineering",
        Salary = 4500000m
    };
    return Results.Ok(coordinator);
});

app.MapGet("/api/enrollment/register/{documentNumber}/{initialPayment}", (
    int documentNumber, 
    decimal initialPayment,
    IPayment payment, 
    Enrollment enrollment, 
    List<Student> allStudents,
    List<Course> allCourses) =>
{
    var student = allStudents.FirstOrDefault(s => s.GetDocumentNumber() == documentNumber);
    
    if (student == null)
    {
        return Results.NotFound($"Student with document number {documentNumber} not found.");
    }

    try
    {
        var selectedCourseCodes = new[] { "POO101", "BDA202", "FIN202" }; 
        
        enrollment.EnrollmentId = new Random().Next(2000, 3000);
        enrollment.Student = student;
        
        enrollment.Courses = allCourses
            .Where(c => selectedCourseCodes.Contains(c.Code))
            .ToList<ICourse>();
        
        enrollment.RegisterEnrollment();

        if (payment is Payment concretePayment)
        {
            concretePayment.EnrollmentContext = enrollment;
        }
        
        enrollment.MakePayment(initialPayment); 
        
        return Results.Ok(new 
        {
            Message = $"Enrollment {enrollment.EnrollmentId} registered successfully!",
            Enrollment = enrollment 
        });
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
});

app.MapGet("/api/enrollment/heavy/{documentNumber}", (
    int documentNumber, 
    IPayment payment,
    Enrollment enrollment, 
    List<Student> allStudents,
    List<Course> allCourses) =>
{
    var student = allStudents.FirstOrDefault(s => s.GetDocumentNumber() == documentNumber);
    
    if (student == null)
    {
        return Results.NotFound($"Student with document number {documentNumber} not found.");
    }

    try
    {
        var selectedCourseCodes = new[] { "POO101", "BDA202", "FIN202", "MKT101" }; 
        
        enrollment.EnrollmentId = new Random().Next(3000, 4000);
        enrollment.Student = student;
        
        enrollment.Courses = allCourses
            .Where(c => selectedCourseCodes.Contains(c.Code))
            .ToList<ICourse>();
        
        enrollment.RegisterEnrollment();
        
        if (payment is Payment concretePayment)
        {
            concretePayment.EnrollmentContext = enrollment;
        }

        enrollment.MakePayment(enrollment.TotalCost);
        
        return Results.Ok(new 
        {
            Message = $"Enrollment {enrollment.EnrollmentId} registered with heavy course load!",
            Enrollment = enrollment 
        });
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
});
app.Run();