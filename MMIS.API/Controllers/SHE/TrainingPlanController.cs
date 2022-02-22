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

    public class TrainingPlanController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public TrainingPlanController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingPlan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingPlan>>> GetTrainingPlan()
        {
            return await _context.TrainingPlan.ToListAsync();
        }

        // GET: api/TrainingPlan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingPlan>> GetTrainingPlan(int id)
        {
            var trainingPlan = await _context.TrainingPlan.FindAsync(id);

            if (trainingPlan == null)
            {
                return NotFound();
            }

            return trainingPlan;
        }

        // PUT: api/TrainingPlan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingPlan(int id, TrainingPlan trainingPlan)
        {
            if (id != trainingPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingPlanExists(id))
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

        // POST: api/TrainingPlan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrainingPlan>> PostTrainingPlan(TrainingPlan trainingPlan)
        {
            _context.TrainingPlan.Add(trainingPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingPlan", new { id = trainingPlan.Id }, trainingPlan);
        }

        // DELETE: api/TrainingPlan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrainingPlan>> DeleteTrainingPlan(int id)
        {
            var trainingPlan = await _context.TrainingPlan.FindAsync(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }

            _context.TrainingPlan.Remove(trainingPlan);
            await _context.SaveChangesAsync();

            return trainingPlan;
        }

        private bool TrainingPlanExists(int id)
        {
            return _context.TrainingPlan.Any(e => e.Id == id);
        }
    }
}
