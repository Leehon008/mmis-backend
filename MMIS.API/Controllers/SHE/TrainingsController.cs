using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class TrainingsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public TrainingsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainings>>> GetTrainings()
        {
            return await _context.Trainings.ToListAsync();
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainings>> GetTrainings(int id)
        {
            var trainings = await _context.Trainings.FindAsync(id);

            if (trainings == null)
            {
                return NotFound();
            }

            return trainings;
        }

        // PUT: api/Trainings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainings(int id, Trainings trainings)
        {
            if (id != trainings.Id)
            {
                return BadRequest();
            }
            trainings.DateCreated = DateTime.Now;
            trainings.DateModified = DateTime.Now;
            _context.Entry(trainings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingsExists(id))
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

        // POST: api/Trainings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trainings>> PostTrainings(Trainings trainings)
        {
            trainings.DateCreated = DateTime.Now;
            trainings.DateModified = DateTime.Now;
            _context.Trainings.Add(trainings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainings", new { id = trainings.Id }, trainings);
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trainings>> DeleteTrainings(int id)
        {
            var trainings = await _context.Trainings.FindAsync(id);
            if (trainings == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(trainings);
            await _context.SaveChangesAsync();

            return trainings;
        }

        private bool TrainingsExists(int id)
        {
            return _context.Trainings.Any(e => e.Id == id);
        }
    }
}
