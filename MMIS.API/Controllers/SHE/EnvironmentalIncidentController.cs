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

    public class EnvironmentalIncidentController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public EnvironmentalIncidentController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvironmentalIncident
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvironmentalIncident>>> GetEnvironmentalIncident()
        {
            return await _context.EnvironmentalIncident.ToListAsync();
        }

        // GET: api/EnvironmentalIncident/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvironmentalIncident>> GetEnvironmentalIncident(int id)
        {
            var environmentalIncident = await _context.EnvironmentalIncident.FindAsync(id);

            if (environmentalIncident == null)
            {
                return NotFound();
            }

            return environmentalIncident;
        }

        // PUT: api/EnvironmentalIncident/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmentalIncident(int id, EnvironmentalIncident environmentalIncident)
        {
            if (id != environmentalIncident.Id)
            {
                return BadRequest();
            }
            environmentalIncident.DateModified = DateTime.Now;
            _context.Entry(environmentalIncident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentalIncidentExists(id))
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

        // POST: api/EnvironmentalIncident
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]

        public async Task<ActionResult<EnvironmentalIncident>> PostEnvironmentalIncident(EnvironmentalIncident environmentalIncident)
        {
            environmentalIncident.DateCreated = DateTime.Now;
            environmentalIncident.DateModified = DateTime.Now;
            _context.EnvironmentalIncident.Add(environmentalIncident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironmentalIncident", new { id = environmentalIncident.Id }, environmentalIncident);
        }

        // DELETE: api/EnvironmentalIncident/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnvironmentalIncident>> DeleteEnvironmentalIncident(int id)
        {
            var environmentalIncident = await _context.EnvironmentalIncident.FindAsync(id);
            if (environmentalIncident == null)
            {
                return NotFound();
            }

            _context.EnvironmentalIncident.Remove(environmentalIncident);
            await _context.SaveChangesAsync();

            return environmentalIncident;
        }

        private bool EnvironmentalIncidentExists(int id)
        {
            return _context.EnvironmentalIncident.Any(e => e.Id == id);
        }
    }
}
