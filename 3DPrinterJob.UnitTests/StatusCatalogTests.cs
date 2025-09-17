using _3DPrinterJob.API.Data.DatabaseContext;
using _3DPrinterJob.API.Models;
using Microsoft.EntityFrameworkCore;


namespace _3DPrinterJob.UnitTests
{

    public class StatusCatalogTests
    {
        // To run this test dotnet test --filter "Name=SeededCatalog_ShouldMatchEnumValues"
        [Fact]
        public void SeededCatalog_ShouldMatchEnumValues()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalogDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated(); // trigger OnModelCreating

            var dbStatuses = context.Statuses
                .Select(s => s.Stat.ToString())
                .ToHashSet();


            var enumStatuses = Enum.GetNames(typeof(StatType));

            Assert.Equal(enumStatuses.Length, dbStatuses.Count);
            foreach (var status in enumStatuses)
            {
                Assert.Contains(status, dbStatuses);
            }
        }
    }
}
