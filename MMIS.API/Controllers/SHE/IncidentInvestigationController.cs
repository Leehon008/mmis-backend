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

    public class IncidentInvestigationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public IncidentInvestigationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/IncidentInvestigation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentInvestigation>>> GetIncidentInvestigation()
        {
            return await _context.IncidentInvestigation.ToListAsync();
        }

        // GET: api/IncidentInvestigation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentInvestigation>> GetIncidentInvestigation(string id)
        {
            int IId = _context.IncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var incidentInvestigation =  _context.IncidentInvestigation.Where(x=>x.Id == IId).FirstOrDefault();
           
        //    int Id = _context.IncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (incidentInvestigation == null)
            {
                return NotFound();
            }

            return incidentInvestigation;
        }

        // PUT: api/IncidentInvestigation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentInvestigation(string id, IncidentInvestigation incidentInvestigation)
        {
            int IId = _context.IncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
        //    int Id = _context.IncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (IId != incidentInvestigation.Id)
            {
                return BadRequest();
            }
            incidentInvestigation.DateModified = DateTime.Now;
            // incidentInvestigation.DateCreated = DateTime.Now;

            _context.Attach(incidentInvestigation);

            var entry = _context.Entry(incidentInvestigation);
            entry.State = EntityState.Modified;
            entry.Property(e => e.DateCreated).IsModified = false;

            foreach (var navigationProperty in incidentInvestigation.IncidentInvestigationPPEList.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentInvestigation.Find(incidentInvestigation.Id)
                        .IncidentInvestigationPPEList.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in incidentInvestigation.IncidentInvestigationDoneDifferent.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentInvestigation.Find(incidentInvestigation.Id)
                        .IncidentInvestigationDoneDifferent.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in incidentInvestigation.IncidentInvestigationSteps.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentInvestigation.Find(incidentInvestigation.Id)
                        .IncidentInvestigationSteps.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in incidentInvestigation.IncidentInvestigationToolCondition.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.IncidentInvestigation.Find(incidentInvestigation.Id)
                        .IncidentInvestigationToolCondition.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }


            _context.Entry(incidentInvestigation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentInvestigationExists(IId))
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

        // POST: api/IncidentInvestigation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IncidentInvestigation>> PostIncidentInvestigation(IncidentInvestigation incidentInvestigation)
        {
            incidentInvestigation.DateModified = DateTime.Now;
            incidentInvestigation.DateCreated = DateTime.Now;
          

            _context.IncidentInvestigation.Add(incidentInvestigation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidentInvestigation", new { id = incidentInvestigation.Id }, incidentInvestigation);
        }

        // DELETE: api/IncidentInvestigation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentInvestigation>> DeleteIncidentInvestigation(int id)
        {
            var incidentInvestigation = await _context.IncidentInvestigation.FindAsync(id);
            if (incidentInvestigation == null)
            {
                return NotFound();
            }

            _context.IncidentInvestigation.Remove(incidentInvestigation);
            await _context.SaveChangesAsync();

            return incidentInvestigation;
        }

        private bool IncidentInvestigationExists(int id)
        {
            return _context.IncidentInvestigation.Any(e => e.Id == id);
        }
    }
}
