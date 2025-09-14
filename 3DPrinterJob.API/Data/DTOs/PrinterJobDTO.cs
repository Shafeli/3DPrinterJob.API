using _3DPrinterJob.API.Models;
using System.ComponentModel.DataAnnotations;

namespace _3DPrinterJob.API.Data.DTOs;

// StatusMutationDTO split into two for clarity and REST conventions as well as setup for partial updates, role-based constraints.
public class CreatePrinterJobDto
{

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Url]
    public string? DownloadLink { get; set; }
    public string? Notes { get; set; }

    [Required]
    public int RequesterId { get; set; }
}

public class UpdatePrinterJobDto : CreatePrinterJobDto
{

    [Required]
    [StringLength(1500, MinimumLength = 5, ErrorMessage = "Notes must be at least 5 characters.")]
    public string Notes { get; set; }

    public int? StatusId { get; set; }
}


public record PrinterJobReadDto(
    int Id,

    string Name,

    string? DownloadLink,
    string? Notes,

    int StatusId,
    StatusReadDto Status,

    int RequesterId,
    RequesterReadDto Requester,

    DateTime CreatedDate
);
