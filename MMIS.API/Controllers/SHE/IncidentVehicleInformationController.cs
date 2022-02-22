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

    public class IncidentVehicleInformationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public IncidentVehicleInformationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/IncidentVehicleInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentVehicleInformation>>> GetIncidentVehicleInformation()
        {
            return await _context.IncidentVehicleInformation.ToListAsync();
        }

        // GET: api/IncidentVehicleInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentVehicleInformation>> GetIncidentVehicleInformation(string id)
        {
            int IId = _context.IncidentVehicleInformation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var incidentVehicleInformation = _context.IncidentVehicleInformation.Where(x => x.Id == IId).FirstOrDefault();

            if (incidentVehicleInformation == null)
            {
                return NotFound();
            }

            return incidentVehicleInformation;
        }

        // PUT: api/IncidentVehicleInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentVehicleInformation(string id, IncidentVehicleInformation incidentVehicleInformation)
        {
            int IId = _context.IncidentVehicleInformation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (IId != incidentVehicleInformation.Id)
            {
                return BadRequest();
            }
            incidentVehicleInformation.DateModified = DateTime.Now;
            _context.Entry(incidentVehicleInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentVehicleInformationExists(IId))
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

        // POST: api/IncidentVehicleInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IncidentVehicleInformation>> PostIncidentVehicleInformation(IncidentVehicleInformation incidentVehicleInformation)
        {
            incidentVehicleInformation.DateModified = DateTime.Now;
            incidentVehicleInformation.DateCreated = DateTime.Now;
            _context.IncidentVehicleInformation.Add(incidentVehicleInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidentVehicleInformation", new { id = incidentVehicleInformation.Id }, incidentVehicleInformation);
        }

        // DELETE: api/IncidentVehicleInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentVehicleInformation>> DeleteIncidentVehicleInformation(int id)
        {
            var incidentVehicleInformation = await _context.IncidentVehicleInformation.FindAsync(id);
            if (incidentVehicleInformation == null)
            {
                return NotFound();
            }

            _context.IncidentVehicleInformation.Remove(incidentVehicleInformation);
            await _context.SaveChangesAsync();

            return incidentVehicleInformation;
        }

        private bool IncidentVehicleInformationExists(int id)
        {
            return _context.IncidentVehicleInformation.Any(e => e.Id == id);
        }
    }
}
