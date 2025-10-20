using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public class Personal : Person, IResponsible
{
    public string Position { get; set; }
    public string Department  { get; set; }
    public decimal Salary  { get; set; }
    public string EmployeeCode  { get; set; }

    public Personal(string name, string lastName, int documentNumber)
    {
        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
        EmployeeCode = $"STAFF{documentNumber}";
    }

    public override void ShowInformation()
    {
        PersonalReport.ShowPersonalDetails(this); 
    }
}