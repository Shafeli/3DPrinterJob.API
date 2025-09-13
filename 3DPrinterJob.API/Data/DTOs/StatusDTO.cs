using _3DPrinterJob.API.Models;
using System.ComponentModel.DataAnnotations;

namespace _3DPrinterJob.API.Data.DTOs;


// StatusMutationDTO split into two for clarity and REST conventions as well as setup for partial updates, role-based constraints.
public class CreateStatusDto
{
    [Required]
    public StatType Stat { get; set; }
}

public class UpdateStatusDto : CreateStatusDto
{
    [Required]
    public int Id { get; set; }

}

public record StatusReadDto(
    int Id,
    StatType Stat
);