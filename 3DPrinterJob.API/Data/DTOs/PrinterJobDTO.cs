using _3DPrinterJob.API.Models;
using System.ComponentModel.DataAnnotations;

namespace _3DPrinterJob.API.Data.DTOs;

public class PrinterJobDTO
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string DownloadLink { get; set; }
    public string Notes { get; set; }

    public int StatusId { get; set; }
    public StatusReadDto Status { get; set; }

    public int RequesterId { get; set; }
    public RequesterDTO Requester { get; set; }

}

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

public class UpdatePrinterJobDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Notes { get; set; }
    public int StatusId { get; set; }

    [Required]
    public int RequesterId { get; set; }
}