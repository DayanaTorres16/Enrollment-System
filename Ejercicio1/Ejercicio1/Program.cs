using Ejercicio1.Miembros;
using Ejercicio1.Matricula;

class Program
{
    static void Main()
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
        
        matricula1.Materias.Add(new Materia { Codigo = "POO101", Nombre = "Programacion Orientada a Objetos", Creditos = 4 });
        matricula1.Materias.Add(new Materia { Codigo = "BDA202", Nombre = "Bases de Datos Avanzadas", Creditos = 3 });
        matricula1.Materias.Add(new Materia { Codigo = "EDT303", Nombre = "Estructuras de Datos", Creditos = 3 });
        matricula1.Materias.Add(new Materia { Codigo = "ISO404", Nombre = "Ingenieria de Software", Creditos = 4 });

        matricula1.RegistrarMatricula();
        matricula1.RealizarPago(1000000m);
        matricula1.RealizarPago(1500000m);
        MatriculaReporte.MostrarDetallesMatricula(matricula1); 

        Console.WriteLine("\n\nSegunda Matricula\n");
        Matricula matricula2 = new Matricula
        {
            IdMatricula = 1002,
            Estudiante = estudiante2,
            CostoTotal = 2200000m,
            ResponsableRegistro = secretaria
        };
        
        matricula2.Materias.Add(new Materia { Codigo = "MKT101", Nombre = "Marketing Digital", Creditos = 3 });
        matricula2.Materias.Add(new Materia { Codigo = "FIN202", Nombre = "Finanzas Corporativas", Creditos = 4 });
        matricula2.Materias.Add(new Materia { Codigo = "GPR303", Nombre = "Gestion de Proyectos", Creditos = 3 });

        matricula2.RegistrarMatricula();
        matricula2.RealizarPago(2200000m);
        MatriculaReporte.MostrarDetallesMatricula(matricula2); 

        Console.WriteLine("\n\nPRUEBA DE CANCELACION\n");
        MatriculaReporte.MostrarDetallesMatricula(matricula2); 
    }
}
