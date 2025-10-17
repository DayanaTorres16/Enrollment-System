namespace Ejercicio1.Miembros;

public abstract class Person
{
    public string Name { get; set; }
    public string LastName { get; set; }
    protected int DocumentNumber  { get; set; }
    public string Email { get; set; }
    public string PhoneNumber  { get; set; }

    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }
    public int GetDocumentNumber()
    {
        return DocumentNumber;
    }
    public abstract void ShowInformation();
}