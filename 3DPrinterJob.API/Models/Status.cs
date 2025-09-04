namespace _3DPrinterJob.API.Models
{
    public class Status
    {
        public int Id { get; set; }                                 // id of the status
        public StatType stat { get; set; }                          // name of the status (e.g., "Pending", "In Progress", "Completed")
    }
}
