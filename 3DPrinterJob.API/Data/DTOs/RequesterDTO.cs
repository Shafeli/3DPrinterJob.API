using _3DPrinterJob.API.Models;
using System.ComponentModel.DataAnnotations;

namespace _3DPrinterJob.API.Data.DTOs;

// expand info later email, role, job count.
public class CreateRequesterDto
{
    [Required]
    public string Name { get; set; }
}

// MutationDTO split into two for clarity and REST conventions as well as setup for partial updates, role-based constraints.

public class UpdateRequesterDto : CreateRequesterDto
{
    [Required]
    public int Id { get; set; }
}

public record RequesterReadDto(
    int Id,
    string Name
);