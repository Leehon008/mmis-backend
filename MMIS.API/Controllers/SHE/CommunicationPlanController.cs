using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

using Microsoft.AspNetCore.Authorization;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class CommunicationPlanController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CommunicationPlanController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunicationPlan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunicationPlan>>> GetCommunicationPlan()
        {
            return await _context.CommunicationPlan.ToListAsync();
        }

        // GET: api/CommunicationPlan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunicationPlan>> GetCommunicationPlan(int id)
        {
            var communicationPlan = await _context.CommunicationPlan.FindAsync(id);

            if (communicationPlan == null)
            {
                return NotFound();
            }

            return communicationPlan;
        }

        // PUT: api/CommunicationPlan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunicationPlan(int id, CommunicationPlan communicationPlan)
        {
            if (id != communicationPlan.Id)
            {
                return BadRequest();
            }
            communicationPlan.DateModified = DateTime.Now;
          
            _context.Entry(communicationPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunicationPlanExists(id))
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

        // POST: api/CommunicationPlan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommunicationPlan>> PostCommunicationPlan(CommunicationPlan communicationPlan)
        {
            communicationPlan.DateModified = DateTime.Now;
            communicationPlan.DateCreated = DateTime.Now;
            _context.CommunicationPlan.Add(communicationPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunicationPlan", new { id = communicationPlan.Id }, communicationPlan);
        }

        // DELETE: api/CommunicationPlan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommunicationPlan>> DeleteCommunicationPlan(int id)
        {
            var communicationPlan = await _context.CommunicationPlan.FindAsync(id);
            if (communicationPlan == null)
            {
                return NotFound();
            }

            _context.CommunicationPlan.Remove(communicationPlan);
            await _context.SaveChangesAsync();

            return communicationPlan;
        }

        private bool CommunicationPlanExists(int id)
        {
            return _context.CommunicationPlan.Any(e => e.Id == id);
        }
    }
}
