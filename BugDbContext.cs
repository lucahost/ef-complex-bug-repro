using EF.ComplexPropertyBug.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.ComplexPropertyBug;

public class BugDbContext(DbContextOptions<BugDbContext> options) : DbContext(options)
{
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<OrderPosition> OrderPositions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shipment>()
            .HasKey(s => s.Id);
        
        modelBuilder.Entity<Shipment>()
            .ComplexProperty(
                shipment => shipment.Recipient,
                complexPropertyBuilder => complexPropertyBuilder
                    .ComplexProperty(
                        recipient => recipient.Address,
                        addressBuilder => addressBuilder.Property(address => address.Id)
                            .HasColumnName("AddressId")
                            .HasConversion(
                                convertToProviderExpression: id => id.Value.UnwrapOr(0),
                                convertFromProviderExpression: value => Id.CreateWithoutValidation<Address>(value))
                            .IsRequired())
                    .ComplexProperty(
                        recipient => recipient.Customer,
                        customerBuilder => customerBuilder.Property(customer => customer.Id)
                            .HasColumnName("CustomerId")
                            .HasConversion(
                                convertToProviderExpression: id => id.Value.UnwrapOr(0),
                                convertFromProviderExpression: value => Id.CreateWithoutValidation<Customer>(value))
                            .IsRequired())
                    .ComplexProperty(
                        recipient => recipient.Person,
                        personBuilder => personBuilder.Property(person => person.Id)
                            .HasColumnName("Person")
                            .HasConversion(
                                convertToProviderExpression: id => id.Value.UnwrapOr(0),
                                convertFromProviderExpression: value => Id.CreateWithoutValidation<Person>(value))
                            .IsRequired()));
        
        modelBuilder.Entity<OrderPosition>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<OrderPosition>()
            .ComplexProperty(
                shipment => shipment.Recipient,
                complexPropertyBuilder => complexPropertyBuilder
                    .ComplexProperty(
                        recipient => recipient.Address,
                        addressBuilder => addressBuilder.Property(address => address.Id)
                            .HasColumnName("AddressId")
                            .HasConversion(
                                convertToProviderExpression: id => id.Value.UnwrapOr(0),
                                convertFromProviderExpression: value => Id.CreateWithoutValidation<Address>(value))
                            .IsRequired())
                    .ComplexProperty(
                        recipient => recipient.Customer,
                        customerBuilder => customerBuilder.Property(customer => customer.Id)
                            .HasColumnName("CustomerId")
                            .HasConversion(
                                convertToProviderExpression: id => id.Value.UnwrapOr(0),
                                convertFromProviderExpression: value => Id.CreateWithoutValidation<Customer>(value))
                            .IsRequired())
                    .ComplexProperty(
                        recipient => recipient.Person,
                        buyerPersonBuilder => buyerPersonBuilder.Property(person => person.Id)
                            .HasColumnName("PersonId")
                            .HasConversion(
                                convertToProviderExpression: id => id.Value.UnwrapOr(0),
                                convertFromProviderExpression: value => Id.CreateWithoutValidation<Person>(value))
                            .IsRequired()));
    }
}