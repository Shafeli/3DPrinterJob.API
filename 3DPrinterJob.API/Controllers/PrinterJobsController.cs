using _3DPrinterJob.API.Data.DatabaseContext;
using _3DPrinterJob.API.Data.DTOs;
using _3DPrinterJob.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrinterJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterJobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrinterJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrinterJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrinterJobReadDto>>> GetPrinterJobs()
        {
            var printerJobs = await _context.PrinterJobs
                .Include(pj => pj.Status)
                .Include(pj => pj.Requester)
                .Select(pj => new PrinterJobReadDto(
                    pj.Id,
                    pj.Name,
                    pj.DownloadLink,
                    pj.Notes,
                    pj.StatusId,
                    new StatusReadDto(pj.StatusId, pj.Status.Stat),
                    pj.RequesterId,
                    new RequesterReadDto(pj.RequesterId, pj.Requester.Name),
                    pj.CreatedDate))
                .ToListAsync();

            return Ok(printerJobs);
        }

        // GET: api/PrinterJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrinterJobReadDto>> GetPrinterJob(int id)
        {
            var printerJob = await _context.PrinterJobs
                .Include(pj => pj.Status)
                .Include(pj => pj.Requester)
                .Select(pj => new PrinterJobReadDto(
                    pj.Id,
                    pj.Name,
                    pj.DownloadLink,
                    pj.Notes,
                    pj.StatusId,
                    new StatusReadDto(pj.StatusId, pj.Status.Stat),
                    pj.RequesterId,
                    new RequesterReadDto(pj.RequesterId, pj.Requester.Name),
                    pj.CreatedDate))
                .FirstOrDefaultAsync(q => q.Id == id);

            if (printerJob == null)
            {
                return NotFound();
            }

            return printerJob;
        }

        // PUT: api/PrinterJobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrinterJob(int id, [FromBody] UpdatePrinterJobDto printerJobUpdate)
        {
            if (id != printerJobUpdate.Id)
            {
                return BadRequest();
            }

            var printerJob = await _context.PrinterJobs.FindAsync(id);
            if (printerJob == null)
            {
                return NotFound();
            }

            printerJob.Name = printerJobUpdate.Name;
            printerJob.DownloadLink = printerJobUpdate.DownloadLink;

            printerJob.Notes = string.IsNullOrEmpty(printerJob.Notes)
                ? printerJobUpdate.Notes
                : printerJob.Notes + $"\n[{DateTime.UtcNow}] {printerJobUpdate.Notes}";

            if (printerJobUpdate.StatusId.HasValue)
            {
                printerJob.StatusId = printerJobUpdate.StatusId.Value;
            }

            _context.Entry(printerJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrinterJobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PrinterJobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrinterJob>> PostPrinterJob(CreatePrinterJobDto newPrinterJob)
        {
            var printerJob = new PrinterJob
            {
                Name = newPrinterJob.Name,
                DownloadLink = newPrinterJob.DownloadLink,
                Notes = newPrinterJob.Notes,
                RequesterId = newPrinterJob.RequesterId,
                StatusId = 1 // Default to "Submitted"
            };

            _context.PrinterJobs.Add(printerJob);
            await _context.SaveChangesAsync();

            var readDto = new PrinterJobReadDto(
                printerJob.Id,
                printerJob.Name,
                printerJob.DownloadLink,
                printerJob.Notes,
                printerJob.StatusId,
                new StatusReadDto(printerJob.StatusId, (await _context.Statuses.FindAsync(printerJob.StatusId)).Stat),
                printerJob.RequesterId,
                new RequesterReadDto(printerJob.RequesterId, (await _context.Requesters.FindAsync(printerJob.RequesterId)).Name),
                printerJob.CreatedDate
            );

            return CreatedAtAction(nameof(GetPrinterJob), new { id = printerJob.Id }, readDto);
        }

        // DELETE: api/PrinterJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrinterJob(int id)
        {
            var printerJob = await _context.PrinterJobs.FindAsync(id);
            if (printerJob == null)
            {
                return NotFound();
            }

            _context.PrinterJobs.Remove(printerJob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrinterJobExists(int id)
        {
            return _context.PrinterJobs.Any(e => e.Id == id);
        }
    }
}
