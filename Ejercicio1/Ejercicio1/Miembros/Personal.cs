using Ejercicio1.Abstracciones;
namespace Ejercicio1.Miembros;

public class Staff : Person, IResponsible
{
    public string Position { get; set; }
    public string Department  { get; set; }
    public decimal Salary  { get; set; }
    public string EmployeeCode  { get; set; }

    public Staff(string name, string lastName, int documentNumber)
    {
        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
        EmployeeCode = $"STAFF{documentNumber}";
    }

    public override void ShowInformation()
    {
        Console.WriteLine("\nSTAFF INFORMATION");
        Console.WriteLine($"Code: {EmployeeCode}");
        Console.WriteLine($"Name: {GetFullName()}");
        Console.WriteLine($"Document Number: {DocumentNumber}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine($"Position: {Position}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: ${Salary:N2}");
    }
}