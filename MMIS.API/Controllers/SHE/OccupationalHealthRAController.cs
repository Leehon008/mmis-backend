using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class OccupationalHealthRAController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public OccupationalHealthRAController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/OccupationalHealthRA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccupationalHeader>>> GetOccupationalHeader()
        {
            return await _context.OccupationalHeader.ToListAsync();
        }

        // GET: api/OccupationalHealthRA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccupationalHeader>> GetOccupationalHeader(int id)
        {
            var occupationalHeader = await _context.OccupationalHeader.FindAsync(id);

            if (occupationalHeader == null)
            {
                return NotFound();
            }

            return occupationalHeader;
        }

        // PUT: api/OccupationalHealthRA/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccupationalHeader(int id, OccupationalHeader occupationalHeader)
        {
            if (id != occupationalHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(occupationalHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccupationalHeaderExists(id))
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

        // POST: api/OccupationalHealthRA
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OccupationalHeader>> PostOccupationalHeader(OccupationalHeader occupationalHeader)
        {
            _context.OccupationalHeader.Add(occupationalHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOccupationalHeader", new { id = occupationalHeader.Id }, occupationalHeader);
        }

        // DELETE: api/OccupationalHealthRA/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OccupationalHeader>> DeleteOccupationalHeader(int id)
        {
            var occupationalHeader = await _context.OccupationalHeader.FindAsync(id);
            if (occupationalHeader == null)
            {
                return NotFound();
            }

            _context.OccupationalHeader.Remove(occupationalHeader);
            await _context.SaveChangesAsync();

            return occupationalHeader;
        }

        private bool OccupationalHeaderExists(int id)
        {
            return _context.OccupationalHeader.Any(e => e.Id == id);
        }
    }
}
