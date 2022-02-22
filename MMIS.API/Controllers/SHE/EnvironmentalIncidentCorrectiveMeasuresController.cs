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

    public class EnvironmentalIncidentCorrectiveMeasuresController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public EnvironmentalIncidentCorrectiveMeasuresController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvironmentalIncidentCorrectiveMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvironmentalIncidentCorrectiveMeasures>>> GetEnvironmentalIncidentCorrectiveMeasures()
        {
            return await _context.EnvironmentalIncidentCorrectiveMeasures.ToListAsync();
        }

        // GET: api/EnvironmentalIncidentCorrectiveMeasures/5
        [HttpGet("{id}")]
        public ActionResult<List<IncidentCorrectiveMeasures>> GetIncidentCorrectiveMeasures(string id)
        {

            //   int IId = _context.IncidentCorrectiveMeasures.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var incidentCorrectiveMeasures = _context.IncidentCorrectiveMeasures.Where(x => x.IncidentNumber == id).ToList();

            if (incidentCorrectiveMeasures == null)
            {
                return NotFound();
            }

            return incidentCorrectiveMeasures;
        }

        // PUT: api/EnvironmentalIncidentCorrectiveMeasures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmentalIncidentCorrectiveMeasures(string id, EnvironmentalIncidentCorrectiveMeasures incidentCorrectiveMeasures)
        {

            int IId = _context.EnvironmentalIncidentCorrectiveMeasures.Where(m => (m.IncidentNumber == id) && (m.Id == incidentCorrectiveMeasures.Id)).Select(m => m.Id).FirstOrDefault();

            if (IId != incidentCorrectiveMeasures.Id)
            {
                return BadRequest();
            }
            incidentCorrectiveMeasures.DateModified = DateTime.Now;
            _context.Entry(incidentCorrectiveMeasures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentCorrectiveMeasuresExists(IId))
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

        // POST: api/EnvironmentalIncidentCorrectiveMeasures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<EnvironmentalIncidentCorrectiveMeasures>> PostEnvironmentalIncidentCorrectiveMeasures(List<EnvironmentalIncidentCorrectiveMeasures> incidentCorrective)
        //{
        //   var incidentCorrectiveMeasures = new IncidentCorrectiveMeasures();
        //    foreach (var x in incidentCorrective)
        //    {
        //        incidentCorrectiveMeasures.IncidentType = x.IncidentType;
        //        incidentCorrectiveMeasures.CreatedBy = x.CreatedBy;
        //        incidentCorrectiveMeasures.Status = x.Status;
        //        incidentCorrectiveMeasures.IncidentNumber = x.IncidentNumber;
        //        incidentCorrectiveMeasures.Title = x.Title;
        //        incidentCorrectiveMeasures.Description = x.Description;
        //        incidentCorrectiveMeasures.AssignedTo = x.AssignedTo;
        //        incidentCorrectiveMeasures.Label = x.Label;
        //        incidentCorrectiveMeasures.DueDate = x.DueDate;

        //        incidentCorrectiveMeasures.DateModified = DateTime.Now;
        //        incidentCorrectiveMeasures.DateCreated = DateTime.Now;
        //        _context.IncidentCorrectiveMeasures.Add(incidentCorrectiveMeasures);
        //        await _context.SaveChangesAsync();
        //    }



        //    return CreatedAtAction("GetEnvironmentalIncidentCorrectiveMeasures", new { id = incidentCorrectiveMeasures.Id }, incidentCorrectiveMeasures);
        //}
        public async Task<ActionResult<EnvironmentalIncidentCorrectiveMeasures>> PostEnvironmentalIncidentCorrectiveMeasures(EnvironmentalIncidentCorrectiveMeasures incidentCorrectiveMeasures)
        {
            incidentCorrectiveMeasures.DateModified = DateTime.Now;
            incidentCorrectiveMeasures.DateCreated = DateTime.Now;
            _context.EnvironmentalIncidentCorrectiveMeasures.Add(incidentCorrectiveMeasures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironmentalIncidentCorrectiveMeasures", new { id = incidentCorrectiveMeasures.Id }, incidentCorrectiveMeasures);
        }

        // DELETE: api/EnvironmentalIncidentCorrectiveMeasures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnvironmentalIncidentCorrectiveMeasures>> DeleteEnvironmentalIncidentCorrectiveMeasures(int id)
        {
            var incidentCorrectiveMeasures = await _context.EnvironmentalIncidentCorrectiveMeasures.FindAsync(id);
            if (incidentCorrectiveMeasures == null)
            {
                return NotFound();
            }

            _context.EnvironmentalIncidentCorrectiveMeasures.Remove(incidentCorrectiveMeasures);
            await _context.SaveChangesAsync();

            return incidentCorrectiveMeasures;
        }

        private bool IncidentCorrectiveMeasuresExists(int id)
        {
            return _context.EnvironmentalIncidentCorrectiveMeasures.Any(e => e.Id == id);
        }
    }
}
