using EF.ComplexPropertyBug;
using EF.ComplexPropertyBug.Models;
using Microsoft.EntityFrameworkCore;

await using var bugDbContext = new BugDbContext(new DbContextOptionsBuilder<BugDbContext>()
    .UseSqlServer("Server=localhost;Database=EFCoreComplexPropertyBug;User ID=sa;Password=superSecretBatterHorse!142;Encrypt=False;")
    .Options);

bugDbContext.Database.EnsureDeleted();
bugDbContext.Database.EnsureCreated();

var shipment = new Shipment
{
    Recipient = new Recipient
    {
        Address = new Address { Id = Id.CreateWithoutValidation<Address>(1) },
        Customer = new Customer { Id = Id.CreateWithoutValidation<Customer>(2) },
        Person = new Person { Id = Id.CreateWithoutValidation<Person>(3) }
    }
};

var shipments = bugDbContext.Shipments.Where(s => s.Recipient == shipment.Recipient)
    .ToList();