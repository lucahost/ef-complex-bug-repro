namespace EF.ComplexPropertyBug.Models;

public record Recipient
{
    public required Address Address { get; init; }
    public required Customer Customer { get; init; }
    public required Person Person { get; init; }
}