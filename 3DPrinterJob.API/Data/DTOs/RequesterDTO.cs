using _3DPrinterJob.API.Models;

namespace _3DPrinterJob.API.Data.DTOs;

// expand info later email, role, job count.
public class RequesterDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// MutationDTO split into two for clarity and REST conventions as well as setup for partial updates, role-based constraints.
public class CreateRequesterDto
{
    public string Name { get; set; }
}

public class UpdateRequesterDto
{
    public string Name { get; set; }
}