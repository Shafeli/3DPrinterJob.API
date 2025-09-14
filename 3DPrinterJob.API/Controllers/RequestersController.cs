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
    public class RequestersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequestersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Requesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequesterReadDto>>> GetRequesters()
        {
            var requesters = await _context.Requesters
                .Select(r => new RequesterReadDto(r.Id, r.Name))
                .ToListAsync();

            return Ok(requesters);
        }

        // GET: api/Requesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequesterReadDto>> GetRequester(int id)
        {
            var requester = await _context.Requesters
                .Select(r => new RequesterReadDto(
                    r.Id,
                    r.Name))
                .FirstOrDefaultAsync(q => q.Id == id);

            if (requester == null)
            {
                return NotFound();
            }

            return requester;
        }

        // PUT: api/Requesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequester(int id, [FromBody] UpdateRequesterDto requester)
        {
            if (id != requester.Id)
            {
                return BadRequest();
            }

            var requesterEntity = await _context.Requesters.FindAsync(id);
            if (requesterEntity == null)
            {
                return NotFound();
            }
            requesterEntity.Name = requester.Name;

            _context.Entry(requesterEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequesterExists(id))
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

        // POST: api/Requesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requester>> PostRequester(CreateRequesterDto newRequester)
        {
            var requester = new Requester
            {
                Name = newRequester.Name
            };

            _context.Requesters.Add(requester);
            await _context.SaveChangesAsync();

            var readDTO = new RequesterReadDto(requester.Id, requester.Name);
            return CreatedAtAction(nameof(GetRequester), new { id = requester.Id }, readDTO);
        }

        // DELETE: api/Requesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequester(int id)
        {
            var requester = await _context.Requesters.FindAsync(id);
            if (requester == null)
            {
                return NotFound();
            }

            _context.Requesters.Remove(requester);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequesterExists(int id)
        {
            return _context.Requesters.Any(e => e.Id == id);
        }
    }
}
