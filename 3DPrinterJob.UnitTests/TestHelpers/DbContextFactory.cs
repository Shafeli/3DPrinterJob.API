using _3DPrinterJob.API.Data.DatabaseContext;
using _3DPrinterJob.API.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DPrinterJob.UnitTests.TestHelpers;

public static class DbContextFactory
{
    // Creates a new in-memory ApplicationDbContext for testing
    public static ApplicationDbContext CreateInMemoryContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        var context = new ApplicationDbContext(options);
        context.Database.EnsureCreated(); // trigger OnModelCreating
        return context;
    }
}


// TODO: Requester dummy data needs to be seeded before connecting PrinterJob dummmy data
public static class DummyData
{
    // Add methods to generate dummy data for tests if needed
    public static PrinterJob CreatePrinterJob(string name = "Test Printer Job")
    {
        return new PrinterJob
        {
            Name = name,
            StatusId = 1, // Assuming 1 corresponds to 'Submitted'
            // RequesterId = 1 // Assuming a requester with ID 1 exists
        };
    }
}

