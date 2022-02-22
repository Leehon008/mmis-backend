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

    public class CostCalculatorController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CostCalculatorController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CostCalculator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostCalculator>>> GetCostCalculator()
        {
            return await _context.CostCalculator.ToListAsync();
        }

        // GET: api/CostCalculator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CostCalculator>> GetCostCalculator(int id)
        {
            var communicationPlan = await _context.CostCalculator.FindAsync(id);

            if (communicationPlan == null)
            {
                return NotFound();
            }

            return communicationPlan;
        }

        // PUT: api/CostCalculator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostCalculator(int id, CostCalculator communicationPlan)
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
                if (!CostCalculatorExists(id))
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

        // POST: api/CostCalculator
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CostCalculator>> PostCostCalculator(CostCalculator communicationPlan)
        {
            communicationPlan.DateModified = DateTime.Now;
            communicationPlan.DateCreated = DateTime.Now;
            _context.CostCalculator.Add(communicationPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostCalculator", new { id = communicationPlan.Id }, communicationPlan);
        }

        // DELETE: api/CostCalculator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CostCalculator>> DeleteCostCalculator(int id)
        {
            var communicationPlan = await _context.CostCalculator.FindAsync(id);
            if (communicationPlan == null)
            {
                return NotFound();
            }

            _context.CostCalculator.Remove(communicationPlan);
            await _context.SaveChangesAsync();

            return communicationPlan;
        }

        private bool CostCalculatorExists(int id)
        {
            return _context.CostCalculator.Any(e => e.Id == id);
        }
    }
}
