using System.Collections.Generic;
using Ejercicio1.Enum;

namespace Ejercicio1.Interfaces;

public interface IStudent
{
    string StudentCode { get; }
    string Career { get; }
    int Semester { get; }
    StudentType Type { get; }
    List<ICourse> EnrolledCourses { get; set; }
    string GetFullName();
}