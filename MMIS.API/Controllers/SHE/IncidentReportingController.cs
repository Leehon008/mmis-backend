using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class IncidentReportingController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly ISendEmailLogic _ISendEmailLogic;

        public IncidentReportingController(MMISDbContext context, ISendEmailLogic ISendEmailLogic)
        {
            _context = context;
            _ISendEmailLogic = ISendEmailLogic;
        }

        // GET: api/IncidentReporting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentLogging>>> GetIncidentLogging()
        {
            return await _context.IncidentLogging.ToListAsync();
        }

        // GET: api/IncidentReporting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentLogging>> GetIncidentLogging(int id)
        {
            var incidentLogging = await _context.IncidentLogging.FindAsync(id);

            if (incidentLogging == null)
            {
                return NotFound();
            }

            return incidentLogging;
        }

        // PUT: api/IncidentReporting/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentLogging(int id, IncidentLogging incidentLogging)
        {
            if (id != incidentLogging.Id)
            {
                return BadRequest();
            }



           // incidentLogging.DateCreated = DateTime.Now;
            incidentLogging.DateModified = DateTime.Now;
           
            _context.Entry(incidentLogging).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentLoggingExists(id))
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

        // POST: api/IncidentReporting
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IncidentLogging>> PostIncidentLogging(IncidentLogging incidentLogging)
        {

            incidentLogging.DateCreated = DateTime.Now;
            incidentLogging.DateModified = DateTime.Now;
            incidentLogging.Status = "Active";
            _context.IncidentLogging.Add(incidentLogging);
            await _context.SaveChangesAsync();
         //   _ISendEmailLogic.sendEmail(incidentLogging);
            return CreatedAtAction("GetIncidentLogging", new { id = incidentLogging.Id }, incidentLogging);
        }

        // DELETE: api/IncidentReporting/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentLogging>> DeleteIncidentLogging(int id)
        {
            var incidentLogging = await _context.IncidentLogging.FindAsync(id);
            if (incidentLogging == null)
            {
                return NotFound();
            }

            _context.IncidentLogging.Remove(incidentLogging);
            await _context.SaveChangesAsync();

            return incidentLogging;
        }

        private bool IncidentLoggingExists(int id)
        {
            return _context.IncidentLogging.Any(e => e.Id == id);
        }
    }
}
