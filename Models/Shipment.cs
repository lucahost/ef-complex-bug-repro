namespace EF.ComplexPropertyBug.Models;

public class Shipment
{
    
    public int Id { get; init; }
    public Recipient Recipient { get; init; }
}