namespace EF.ComplexPropertyBug.Models;

public class Address
{
    public required Id<Address> Id { get; init; }
}