using _3DPrinterJob.API.Data.DatabaseContext;
using _3DPrinterJob.API.Data.DTOs;
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


public static class DummyData
{
    // Add methods to generate dummy data for tests if needed
    public static PrinterJob CreatePrinterJob(string name = "Test Printer Job")
    {
        return new PrinterJob
        {
            Name = name,
            StatusId = 1, // 1 corresponds to 'Submitted'
            Requester = new Requester { Name = "Test Requester" }
        };
    }

    public static CreatePrinterJobDto CreatePrinterJobDto()
    {
        return new CreatePrinterJobDto
        {
            Name = "Test Job",
            Notes = "This is a test job.",
            RequesterId = 1
        };
    }
}

