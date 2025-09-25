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


        // To run this test dotnet test --filter "Name=SeededCatalog_ShouldNotContainDuplicates"
        [Fact]
        public void SeededCatalog_ShouldNotContainDuplicates()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestCatalogDb_NoDuplicates")
                .Options;

            using var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            var duplicates = context.Statuses
                .ToList()
                .GroupBy(s => s.Stat)
                .Where(g => g.Count() > 1)
                .ToList();

            Assert.Empty(duplicates);
        }


        // Tests the enum to db mapping
        // To run this test dotnet test --filter "Name=EnumValues_ShouldMapToCorrectIds"
        [Fact]
        public void EnumValues_ShouldMapToCorrectIds()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestCatalogDb_EnumMapping")
                .Options;

            using var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            foreach (StatType enumValue in Enum.GetValues(typeof(StatType)))
            {
                var status = context.Statuses.SingleOrDefault(s => s.Stat == enumValue);
                Assert.NotNull(status);
                Assert.Equal(enumValue.ToString(), status.Stat.ToString());
            }
        }

    }
}
