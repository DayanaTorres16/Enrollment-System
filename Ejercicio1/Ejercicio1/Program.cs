using System;
using System.Collections.Generic;

interface IMatriculable
{
    void RegistrarMatricula();
    void CancelarMatricula();
    void MostrarDetallesMatricula();
}

interface IPagable
{
    decimal CalcularMontoPendiente();
    void RealizarPago(decimal monto);
    bool EsPagadoCompleto();
}

public abstract class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    protected int Documento { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public string ObtenerNombre()
    {
        return $"{Nombre} {Apellido}";
    }

    public abstract void MostrarInformacion();
}

public class Estudiante : Persona
{
    public string Carrera { get; set; }
    public int Semestre { get; set; }
    public string CodigoEstudiante { get; set; }

    public Estudiante(string nombre, string apellido, int documento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Documento = documento;
        CodigoEstudiante = $"EST{documento}";
    }

    public int ObtenerDocumento()
    {
        return Documento;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("\nINFORMACION DEL ESTUDIANTE");
        Console.WriteLine($"Codigo: {CodigoEstudiante}");
        Console.WriteLine($"Nombre: {ObtenerNombre()}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Telefono: {Telefono}");
        Console.WriteLine($"Carrera: {Carrera}");
        Console.WriteLine($"Semestre: {Semestre}");
    }
}

public class Personal : Persona
{
    public string Cargo { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public string CodigoEmpleado { get; set; }

    public Personal(string nombre, string apellido, int documento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Documento = documento;
        CodigoEmpleado = $"PER{documento}";
    }

    public int ObtenerDocumento()
    {
        return Documento;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("\nINFORMACION DEL PERSONAL");
        Console.WriteLine($"Codigo: {CodigoEmpleado}");
        Console.WriteLine($"Nombre: {ObtenerNombre()}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Telefono: {Telefono}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Departamento: {Departamento}");
        Console.WriteLine($"Salario: ${Salario:N2}");
    }
}

public class Matricula : IMatriculable, IPagable
{
    public int IdMatricula { get; set; }
    public DateTime FechaMatricula { get; set; }
    public string Estado { get; private set; }
    public decimal CostoTotal { get; set; }
    public decimal MontoPagado { get; private set; }
    public Estudiante Estudiante { get; set; }
    public List<string> Materias { get; set; }
    public Personal ResponsableRegistro { get; set; }

    public Matricula()
    {
        Materias = new List<string>();
        Estado = "Pendiente";
        MontoPagado = 0;
    }

    public void RegistrarMatricula()
    {
        if (ValidarMatricula())
        {
            Estado = "Activa";
            FechaMatricula = DateTime.Now;
            Console.WriteLine($"\nMatricula #{IdMatricula} registrada exitosamente");
            Console.WriteLine($"Estudiante: {Estudiante.ObtenerNombre()}");
            Console.WriteLine($"Registrada por: {ResponsableRegistro?.ObtenerNombre() ?? "Sistema"}");
        }
        else
        {
            Console.WriteLine($"\nError: No se pudo registrar la matricula #{IdMatricula}");
        }
    }

    public void CancelarMatricula()
    {
        if (Estado == "Activa")
        {
            Estado = "Cancelada";
            Console.WriteLine($"\nMatricula #{IdMatricula} ha sido cancelada");
        }
        else
        {
            Console.WriteLine($"\nNo se puede cancelar. Estado actual: {Estado}");
        }
    }

    public void MostrarDetallesMatricula()
    {
        Console.WriteLine("\nDETALLE DE MATRICULA");
        Console.WriteLine($"ID Matricula: #{IdMatricula}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine($"Fecha: {FechaMatricula:dd/MM/yyyy}");
        Console.WriteLine($"\nEstudiante:");
        Console.WriteLine($"Nombre: {Estudiante.ObtenerNombre()}");
        Console.WriteLine($"Codigo: {Estudiante.CodigoEstudiante}");
        Console.WriteLine($"Carrera: {Estudiante.Carrera}");
        Console.WriteLine($"Semestre: {Estudiante.Semestre}");
        Console.WriteLine($"\nInformacion Financiera:");
        Console.WriteLine($"Costo Total: ${CostoTotal:N2}");
        Console.WriteLine($"Monto Pagado: ${MontoPagado:N2}");
        Console.WriteLine($"Monto Pendiente: ${CalcularMontoPendiente():N2}");
        Console.WriteLine($"Estado de Pago: {(EsPagadoCompleto() ? "COMPLETO" : "PENDIENTE")}");
        Console.WriteLine($"\nMaterias Inscritas ({Materias.Count}):");
        foreach (var materia in Materias)
        {
            Console.WriteLine($"  - {materia}");
        }
        if (ResponsableRegistro != null)
        {
            Console.WriteLine($"\nRegistrada por: {ResponsableRegistro.ObtenerNombre()} ({ResponsableRegistro.Cargo})");
        }
    }

    public decimal CalcularMontoPendiente()
    {
        return CostoTotal - MontoPagado;
    }

    public void RealizarPago(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("\nEl monto debe ser mayor a 0");
            return;
        }

        if (monto > CalcularMontoPendiente())
        {
            Console.WriteLine($"\nEl monto excede la deuda. Pendiente: ${CalcularMontoPendiente():N2}");
            return;
        }

        MontoPagado += monto;
        Console.WriteLine($"\nPago registrado: ${monto:N2}");
        Console.WriteLine($"Total pagado: ${MontoPagado:N2}");
        Console.WriteLine($"Pendiente: ${CalcularMontoPendiente():N2}");
    }

    public bool EsPagadoCompleto()
    {
        return MontoPagado >= CostoTotal;
    }

    private bool ValidarMatricula()
    {
        return Estudiante != null && 
               Materias.Count > 0 && 
               CostoTotal > 0 &&
               ResponsableRegistro != null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SISTEMA DE MATRICULACION UNIVERSITARIA\n");

        Personal coordinador = new Personal("Carlos", "Rodriguez", 9876543)
        {
            Email = "carlos.rodriguez@universidad.edu",
            Telefono = "+57 320 9876543",
            Cargo = "Coordinador Academico",
            Departamento = "Facultad de Ingenieria",
            Salario = 4500000m
        };

        Personal secretaria = new Personal("Ana", "Martinez", 3456789)
        {
            Email = "ana.martinez@universidad.edu",
            Telefono = "+57 315 3456789",
            Cargo = "Secretaria Academica",
            Departamento = "Registro y Control",
            Salario = 2800000m
        };

        Estudiante estudiante1 = new Estudiante("Juan", "Perez", 1234567)
        {
            Email = "juan.perez@universidad.edu",
            Telefono = "+57 300 1234567",
            Carrera = "Ingenieria de Sistemas",
            Semestre = 5
        };

        Estudiante estudiante2 = new Estudiante("Maria", "Garcia", 7654321)
        {
            Email = "maria.garcia@universidad.edu",
            Telefono = "+57 310 7654321",
            Carrera = "Administracion de Empresas",
            Semestre = 3
        };

        List<Persona> personas = new List<Persona> 
        { 
            coordinador, 
            secretaria, 
            estudiante1, 
            estudiante2 
        };

        Console.WriteLine("MOSTRANDO INFORMACION DE TODAS LAS PERSONAS\n");
        foreach (Persona persona in personas)
        {
            persona.MostrarInformacion();
        }

        Console.WriteLine("\n\nPROCESO DE MATRICULACION\n");

        Matricula matricula1 = new Matricula
        {
            IdMatricula = 1001,
            Estudiante = estudiante1,
            CostoTotal = 2500000m,
            ResponsableRegistro = coordinador
        };
        matricula1.Materias.Add("Programacion Orientada a Objetos");
        matricula1.Materias.Add("Bases de Datos Avanzadas");
        matricula1.Materias.Add("Estructuras de Datos");
        matricula1.Materias.Add("Ingenieria de Software");

        matricula1.RegistrarMatricula();
        matricula1.RealizarPago(1000000m);
        matricula1.RealizarPago(1500000m);
        matricula1.MostrarDetallesMatricula();

        Console.WriteLine("\n\nSegunda Matricula\n");
        Matricula matricula2 = new Matricula
        {
            IdMatricula = 1002,
            Estudiante = estudiante2,
            CostoTotal = 2200000m,
            ResponsableRegistro = secretaria
        };
        matricula2.Materias.Add("Marketing Digital");
        matricula2.Materias.Add("Finanzas Corporativas");
        matricula2.Materias.Add("Gestion de Proyectos");

        matricula2.RegistrarMatricula();
        matricula2.RealizarPago(2200000m);
        matricula2.MostrarDetallesMatricula();

        Console.WriteLine("\n\nPRUEBA DE CANCELACION\n");
        matricula2.CancelarMatricula();

        Console.WriteLine("\nSistema ejecutado exitosamente");
    }
}
