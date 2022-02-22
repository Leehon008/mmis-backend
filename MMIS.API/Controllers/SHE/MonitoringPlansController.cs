using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class MonitoringPlansController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MonitoringPlansController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MonitoringPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitoringPlan>>> GetMonitoringPlan()
        {
            return await _context.MonitoringPlan.ToListAsync();
        }

        // GET: api/MonitoringPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonitoringPlan>> GetMonitoringPlan(int id)
        {
            var monitoringPlan = await _context.MonitoringPlan.FindAsync(id);

            if (monitoringPlan == null)
            {
                return NotFound();
            }

            return monitoringPlan;
        }

        // PUT: api/MonitoringPlans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitoringPlan(int id, MonitoringPlan monitoringPlan)
        {
            if (id != monitoringPlan.Id)
            {
                return BadRequest();
            }
            //monitoringPlan.DateCreated = DateTime.Now;
            monitoringPlan.DateModified = DateTime.Now;
            _context.Entry(monitoringPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitoringPlanExists(id))
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

        // POST: api/MonitoringPlans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MonitoringPlan>> PostMonitoringPlan(MonitoringPlan monitoringPlan)
        {
            monitoringPlan.DateCreated = DateTime.Now;
            monitoringPlan.DateModified = DateTime.Now;
            _context.MonitoringPlan.Add(monitoringPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonitoringPlan", new { id = monitoringPlan.Id }, monitoringPlan);
        }

        // DELETE: api/MonitoringPlans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MonitoringPlan>> DeleteMonitoringPlan(int id)
        {
            var monitoringPlan = await _context.MonitoringPlan.FindAsync(id);
            if (monitoringPlan == null)
            {
                return NotFound();
            }

            _context.MonitoringPlan.Remove(monitoringPlan);
            await _context.SaveChangesAsync();

            return monitoringPlan;
        }

        private bool MonitoringPlanExists(int id)
        {
            return _context.MonitoringPlan.Any(e => e.Id == id);
        }
    }
}
