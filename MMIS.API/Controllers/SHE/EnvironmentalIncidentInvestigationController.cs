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

    public class EnvironmentalIncidentInvestigationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public EnvironmentalIncidentInvestigationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvironmentalIncidentInvestigation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvironmentalIncidentInvestigation>>> GetEnvironmentalIncidentInvestigation()
        {
            return await _context.EnvironmentalIncidentInvestigation.ToListAsync();
        }

        // GET: api/EnvironmentalIncidentInvestigation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvironmentalIncidentInvestigation>> GetEnvironmentalIncidentInvestigation(string id)
        {
            int IId = _context.EnvironmentalIncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var environmentalIncidentInvestigation = _context.EnvironmentalIncidentInvestigation.Where(x => x.Id == IId).FirstOrDefault();

           // var environmentalIncidentInvestigation = await _context.EnvironmentalIncidentInvestigation.FindAsync(id);

            if (environmentalIncidentInvestigation == null)
            {
                return NotFound();
            }

            return environmentalIncidentInvestigation;
        }

        // PUT: api/EnvironmentalIncidentInvestigation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmentalIncidentInvestigation(string id, EnvironmentalIncidentInvestigation environmentalIncidentInvestigation)
        {
            int IId = _context.EnvironmentalIncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (IId != environmentalIncidentInvestigation.Id)
            {
                return BadRequest();
            }
            environmentalIncidentInvestigation.DateModified = DateTime.Now;

            _context.Attach(environmentalIncidentInvestigation);

            var entry = _context.Entry(environmentalIncidentInvestigation);
            entry.State = EntityState.Modified;
            entry.Property(e => e.DateCreated).IsModified = false;

            foreach (var navigationProperty in environmentalIncidentInvestigation.EnvironmentalIncidentDeviationFromVpo.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.EnvironmentalIncidentInvestigation.Find(environmentalIncidentInvestigation.Id)
                        .EnvironmentalIncidentDeviationFromVpo.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            _context.Entry(environmentalIncidentInvestigation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentalIncidentInvestigationExists(IId))
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

        // POST: api/EnvironmentalIncidentInvestigation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnvironmentalIncidentInvestigation>> PostEnvironmentalIncidentInvestigation(EnvironmentalIncidentInvestigation environmentalIncidentInvestigation)
        {
            environmentalIncidentInvestigation.DateModified = DateTime.Now;
            environmentalIncidentInvestigation.DateCreated = DateTime.Now;
            _context.EnvironmentalIncidentInvestigation.Add(environmentalIncidentInvestigation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironmentalIncidentInvestigation", new { id = environmentalIncidentInvestigation.Id }, environmentalIncidentInvestigation);
        }

        // DELETE: api/EnvironmentalIncidentInvestigation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnvironmentalIncidentInvestigation>> DeleteEnvironmentalIncidentInvestigation(int id)
        {
            var environmentalIncidentInvestigation = await _context.EnvironmentalIncidentInvestigation.FindAsync(id);
            if (environmentalIncidentInvestigation == null)
            {
                return NotFound();
            }

            _context.EnvironmentalIncidentInvestigation.Remove(environmentalIncidentInvestigation);
            await _context.SaveChangesAsync();

            return environmentalIncidentInvestigation;
        }

        private bool EnvironmentalIncidentInvestigationExists(int id)
        {
            return _context.EnvironmentalIncidentInvestigation.Any(e => e.Id == id);
        }
    }
}
