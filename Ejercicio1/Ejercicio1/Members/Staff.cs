using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public class Staff : Person, IStaff
{
    public string Position { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public string EmployeeCode { get; set; }

    public Staff(string name, string lastName, int documentNumber)
        :base(name, lastName, documentNumber)
    {
        EmployeeCode = $"STAFF{documentNumber}";
    }
    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }
}