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


public static class DataHelper
{

    public static CreatePrinterJobDto CreatePrinterJobDto(int requesterId)
    {
        return new CreatePrinterJobDto
        {
            Name = "Test Job",
            Notes = "This is a test job.",
            RequesterId = requesterId
        };
    }

    public static Requester SeedRequester(ApplicationDbContext context, string name = "Test Requester")
    {
        var requester = new Requester { Name = name };
        context.Requesters.Add(requester);
        context.SaveChanges();
        return requester;
    }

    public static PrinterJob SeedPrinterJob(ApplicationDbContext context, string name = "Test Job")
    {
        var requester = SeedRequester(context);

        var job = new PrinterJob
        {
            Name = name,
            StatusId = 1,
            RequesterId = requester.Id
        };

        context.PrinterJobs.Add(job);
        context.SaveChanges();
        return job;
    }

}

