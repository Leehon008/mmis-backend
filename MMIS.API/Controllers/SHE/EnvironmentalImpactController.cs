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

    public class EnvironmentalImpactController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public EnvironmentalImpactController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvironmentalImpact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvironmentalImpactRAHeader>>> GetEnvironmentalImpactRAHeader()
        {
            return await _context.EnvironmentalImpactRAHeader.ToListAsync();
        }

        // GET: api/EnvironmentalImpact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvironmentalImpactRAHeader>> GetEnvironmentalImpactRAHeader(int id)
        {
            var environmentalImpactRAHeader = await _context.EnvironmentalImpactRAHeader.FindAsync(id);

            if (environmentalImpactRAHeader == null)
            {
                return NotFound();
            }

            return environmentalImpactRAHeader;
        }

        // PUT: api/EnvironmentalImpact/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmentalImpactRAHeader(int id, EnvironmentalImpactRAHeader environmentalImpactRAHeader)
        {
            if (id != environmentalImpactRAHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(environmentalImpactRAHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentalImpactRAHeaderExists(id))
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

        // POST: api/EnvironmentalImpact
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnvironmentalImpactRAHeader>> PostEnvironmentalImpactRAHeader(EnvironmentalImpactRAHeader environmentalImpactRAHeader)
        {
            _context.EnvironmentalImpactRAHeader.Add(environmentalImpactRAHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironmentalImpactRAHeader", new { id = environmentalImpactRAHeader.Id }, environmentalImpactRAHeader);
        }

        // DELETE: api/EnvironmentalImpact/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnvironmentalImpactRAHeader>> DeleteEnvironmentalImpactRAHeader(int id)
        {
            var environmentalImpactRAHeader = await _context.EnvironmentalImpactRAHeader.FindAsync(id);
            if (environmentalImpactRAHeader == null)
            {
                return NotFound();
            }

            _context.EnvironmentalImpactRAHeader.Remove(environmentalImpactRAHeader);
            await _context.SaveChangesAsync();

            return environmentalImpactRAHeader;
        }

        private bool EnvironmentalImpactRAHeaderExists(int id)
        {
            return _context.EnvironmentalImpactRAHeader.Any(e => e.Id == id);
        }
    }
}
