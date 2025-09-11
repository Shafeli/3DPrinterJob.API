using _3DPrinterJob.API.Models;

namespace _3DPrinterJob.API.Data.DTOs;

    public class StatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }


public class CreateStatusDto
{
    public StatType Stat { get; set; }
}

public class UpdateStatusDto
{
    public StatType Stat { get; set; }
}
