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

    public class IncidentCorrectiveMeasuresController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public IncidentCorrectiveMeasuresController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/IncidentCorrectiveMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentCorrectiveMeasures>>> GetIncidentCorrectiveMeasures()
        {
            return await _context.IncidentCorrectiveMeasures.ToListAsync();
        }

        // GET: api/IncidentCorrectiveMeasures/5
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

        // PUT: api/IncidentCorrectiveMeasures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentCorrectiveMeasures(string id, IncidentCorrectiveMeasures incidentCorrectiveMeasures)
        {
           // int IId = _context.IncidentCorrectiveMeasures.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            int IId = _context.IncidentCorrectiveMeasures.Where(m => (m.IncidentNumber == id) && (m.Id == incidentCorrectiveMeasures.Id)).Select(m => m.Id).FirstOrDefault();
           

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

        // POST: api/IncidentCorrectiveMeasures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<IncidentCorrectiveMeasures>> PostIncidentCorrectiveMeasures(List<IncidentCorrectiveMeasures> incidentCorrective)
        //{
        //    var incidentCorrectiveMeasures = new IncidentCorrectiveMeasures();
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




        //    return CreatedAtAction("GetIncidentCorrectiveMeasures",  incidentCorrectiveMeasures);
        //}
        public async Task<ActionResult<IncidentCorrectiveMeasures>> PostIncidentCorrectiveMeasures(IncidentCorrectiveMeasures incidentCorrectiveMeasures)
        {
            incidentCorrectiveMeasures.DateModified = DateTime.Now;
            incidentCorrectiveMeasures.DateCreated = DateTime.Now;
            _context.IncidentCorrectiveMeasures.Add(incidentCorrectiveMeasures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidentCorrectiveMeasures", new { id = incidentCorrectiveMeasures.Id }, incidentCorrectiveMeasures);
        }

    

        // DELETE: api/IncidentCorrectiveMeasures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentCorrectiveMeasures>> DeleteIncidentCorrectiveMeasures(int id)
        {
            var incidentCorrectiveMeasures = await _context.IncidentCorrectiveMeasures.FindAsync(id);
            if (incidentCorrectiveMeasures == null)
            {
                return NotFound();
            }

            _context.IncidentCorrectiveMeasures.Remove(incidentCorrectiveMeasures);
            await _context.SaveChangesAsync();

            return incidentCorrectiveMeasures;
        }

        private bool IncidentCorrectiveMeasuresExists(int id)
        {
            return _context.IncidentCorrectiveMeasures.Any(e => e.Id == id);
        }
    }
}
