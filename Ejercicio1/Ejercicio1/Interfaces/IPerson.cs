using System;
using Ejercicio1.Interfaces;
namespace Ejercicio1.Members;

public interface IPerson
{
    string Name { get; set; }
    string LastName { get; set; }
    int DocumentNumber { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }

    int GetDocumentNumber();
}