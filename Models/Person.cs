namespace EF.ComplexPropertyBug.Models;

public class Person
{
    public required Id<Person> Id { get; init; }
}