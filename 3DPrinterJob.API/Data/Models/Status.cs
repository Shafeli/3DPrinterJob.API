namespace _3DPrinterJob.API.Models
{
    public enum StatType
    {
        Pending,
        InProgress,
        Completed,
        Failed
    }

    public class Status
    {
        public int Id { get; set; }                                 // id of the status
        public StatType stat { get; set; }                          // name of the status (e.g., "Pending", "In Progress", "Completed")
    }
}
