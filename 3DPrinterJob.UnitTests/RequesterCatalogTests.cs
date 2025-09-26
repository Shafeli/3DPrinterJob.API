using _3DPrinterJob.API.Data.DatabaseContext;
using _3DPrinterJob.UnitTests.TestHelpers;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3DPrinterJob.UnitTests
{
    public class RequesterCatalogTests
    {

        // To run this test dotnet test --filter "Name=SeededCatalog_ShouldNotContainDuplicates"
        [Fact]
        public void SeededCatalog_ShouldNotContainDuplicates()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestCatalogDb_NoDuplicates_Requester")
                .Options;

            using var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            // need to seed some Requesters for testing
            DataHelper.SeedRequester(context, "Bob");
            DataHelper.SeedRequester(context, "Alice");
            DataHelper.SeedRequester(context, "Robert");


            context.SaveChanges();

            var duplicates = context.Requesters
                .ToList()
                .GroupBy(r => r.Name)
                .Where(g => g.Count() > 1)
                .ToList();

            Assert.Empty(duplicates);
        }

        // Additional tests for Requester catalog can be added here.

    }
}
