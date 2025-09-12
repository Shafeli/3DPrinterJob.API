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
    }
}
