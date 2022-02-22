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

    public class TrainingMatrixController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public TrainingMatrixController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingMatrix
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingMatrix>>> GetTrainingMatrix()
        {
            return await _context.TrainingMatrix.ToListAsync();
        }

        // GET: api/TrainingMatrix/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingMatrix>> GetTrainingMatrix(int id)
        {
            var trainingMatrix = await _context.TrainingMatrix.FindAsync(id);

            if (trainingMatrix == null)
            {
                return NotFound();
            }

            return trainingMatrix;
        }

        // PUT: api/TrainingMatrix/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingMatrix(int id, TrainingMatrix trainingMatrix)
        {
            if (id != trainingMatrix.Id)
            {
                return BadRequest();
            }
            trainingMatrix.DateModified = DateTime.Now;

            _context.Entry(trainingMatrix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingMatrixExists(id))
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

        // POST: api/TrainingMatrix
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrainingMatrix>> PostTrainingMatrix(TrainingMatrix trainingMatrix)
        {
            trainingMatrix.DateCreated = DateTime.Now;
            trainingMatrix.DateModified = DateTime.Now;
            _context.TrainingMatrix.Add(trainingMatrix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingMatrix", new { id = trainingMatrix.Id }, trainingMatrix);
        }

        // DELETE: api/TrainingMatrix/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrainingMatrix>> DeleteTrainingMatrix(int id)
        {
            var trainingMatrix = await _context.TrainingMatrix.FindAsync(id);
            if (trainingMatrix == null)
            {
                return NotFound();
            }

            _context.TrainingMatrix.Remove(trainingMatrix);
            await _context.SaveChangesAsync();

            return trainingMatrix;
        }

        private bool TrainingMatrixExists(int id)
        {
            return _context.TrainingMatrix.Any(e => e.Id == id);
        }
    }
}
