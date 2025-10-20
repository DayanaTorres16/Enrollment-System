using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public class Student : Person, IStudent
{
    public string Career { get; set; }
    public int Semester { get; set; }
    public string StudentCode { get; }
    
    public Student(string name, string lastName, int documentNumber)
    {
        Name = name;
        LastName = lastName;
        DocumentNumber = documentNumber;
        StudentCode = $"EST{documentNumber}";
    }
    
    public override void ShowInformation()
    {
        StudentReport.ShowStudentDetails(this);
    }
}