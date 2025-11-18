using System.Collections.Generic;

namespace Ejercicio1.Interfaces;

public interface ICostCalculatorFactory
{
    ICostCalculator CreateCalculator(List<ICourse> courses);
}