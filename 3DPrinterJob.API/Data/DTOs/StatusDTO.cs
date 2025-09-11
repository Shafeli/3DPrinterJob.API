using _3DPrinterJob.API.Models;

namespace _3DPrinterJob.API.Data.DTOs;

    public class StatusDTO
    {
        public int Id { get; set; }
        public StatType StatType { get; set; }
    }

// StatusMutationDTO split into two for clarity and REST conventions as well as setup for partial updates, role-based constraints.
public class CreateStatusDto
{
    public StatType Stat { get; set; }
}

public class UpdateStatusDto
{
    public StatType Stat { get; set; }
}
