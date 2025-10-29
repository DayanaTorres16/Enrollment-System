using System.Collections.Generic;
namespace Ejercicio1.Interfaces;

public interface ICostCalculator
{
    decimal CalculateTotalCost(List<ICourse> courses);
}