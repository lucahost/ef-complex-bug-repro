namespace EF.ComplexPropertyBug.Models;

public class Customer
{
    public required Id<Customer> Id { get; init; }
}