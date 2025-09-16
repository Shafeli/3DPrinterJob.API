using _3DPrinterJob.API.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DPrinterJob.API.Data.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PrinterJob> PrinterJobs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Requester> Requesters { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Status>().HasData(
             new Status { Id = 1, Stat = StatType.Submitted },
             new Status { Id = 2, Stat = StatType.Pending },
             new Status { Id = 3, Stat = StatType.InProgress },
             new Status { Id = 4, Stat = StatType.Completed },
             new Status { Id = 5, Stat = StatType.Failed }
         );

        }

    }
}