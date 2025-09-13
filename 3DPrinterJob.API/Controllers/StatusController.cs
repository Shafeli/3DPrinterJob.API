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
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusReadDto>>> GetStatuses()
        {
            var Stat = await _context.Statuses
                .Select(s => new StatusReadDto(s.Id, s.Stat))
                .ToListAsync();

            return Ok(Stat);
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusReadDto>> GetStatus(int id)
        {
            var status = await _context.Statuses
                .Select(s => new StatusReadDto(
                    s.Id,
                    s.Stat))
                .FirstOrDefaultAsync(q => q.Id == id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, [FromBody] UpdateStatusDto statusUpdate)
        {
            if (id != statusUpdate.Id)
            {
                return BadRequest();
            }

            var stat = await _context.Statuses.FindAsync(id);
            if (stat == null)
            {
                return NotFound();
            }

            stat.Stat = statusUpdate.Stat;

            _context.Entry(stat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(CreateStatusDto newStatus)
        {
            var status = new Status
            {
                Stat = newStatus.Stat
            };

            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            var readDto = new StatusReadDto(status.Id, status.Stat);
            return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, readDto);
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
