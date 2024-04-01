namespace EF.ComplexPropertyBug.Models;

public record OrderPosition
{
    public int Id { get; init; }
    public Recipient Recipient { get; init; }
}