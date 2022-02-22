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

    public class IncidentCausesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public IncidentCausesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/IncidentCauses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentCauses>>> GetIncidentCauses()
        {
            return await _context.IncidentCauses.ToListAsync();
        }

        // GET: api/IncidentCauses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentCauses>> GetIncidentCauses(string id)
        {
            int IId = _context.IncidentCauses.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var incidentCauses = _context.IncidentCauses.Where(x => x.Id == IId).FirstOrDefault();

            if (incidentCauses == null)
            {
                return NotFound();
            }

            return incidentCauses;
        }

        // PUT: api/IncidentCauses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentCauses(string id, IncidentCauses incidentCauses)
        {
            int IId = _context.IncidentCauses.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (IId != incidentCauses.Id)
            {
                return BadRequest();
            }
            incidentCauses.DateModified = DateTime.Now;
            _context.Entry(incidentCauses).State = EntityState.Modified;

            _context.Attach(incidentCauses);

            var entry = _context.Entry(incidentCauses);
            entry.State = EntityState.Modified;
            entry.Property(e => e.DateCreated).IsModified = false;

            foreach (var navigationProperty in incidentCauses.IncidentWhys.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentCauses.Find(incidentCauses.Id)
                        .IncidentWhys.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in incidentCauses.IncidentRootCauseConditions.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentCauses.Find(incidentCauses.Id)
                        .IncidentRootCauseConditions.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in incidentCauses.IncidentRootCauseActions.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentCauses.Find(incidentCauses.Id)
                        .IncidentRootCauseActions.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in incidentCauses.IncidentImmediateCauseConditions.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentCauses.Find(incidentCauses.Id)
                        .IncidentImmediateCauseConditions.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentCausesExists(IId))
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

        // POST: api/IncidentCauses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IncidentCauses>> PostIncidentCauses(IncidentCauses incidentCauses)
        {
            incidentCauses.DateCreated = DateTime.Now;
            incidentCauses.DateCreated = DateTime.Now;
            _context.IncidentCauses.Add(incidentCauses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidentCauses", new { id = incidentCauses.Id }, incidentCauses);
        }

        // DELETE: api/IncidentCauses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentCauses>> DeleteIncidentCauses(int id)
        {
            var incidentCauses = await _context.IncidentCauses.FindAsync(id);
            if (incidentCauses == null)
            {
                return NotFound();
            }

            _context.IncidentCauses.Remove(incidentCauses);
            await _context.SaveChangesAsync();

            return incidentCauses;
        }

        private bool IncidentCausesExists(int id)
        {
            return _context.IncidentCauses.Any(e => e.Id == id);
        }
    }
}
