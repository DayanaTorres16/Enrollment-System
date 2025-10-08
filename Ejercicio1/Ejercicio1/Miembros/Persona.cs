namespace Ejercicio1.Miembros;

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
    public int ObtenerDocumento()
    {
        return Documento;
    }
    public abstract void MostrarInformacion();
}