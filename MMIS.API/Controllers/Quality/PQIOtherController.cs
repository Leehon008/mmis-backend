using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class PQIOtherController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PQIOtherController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PQIOther
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PQIOther>>> GetQualityPQIOther()
        //{
        //    return await _context.QualityPQIOther.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PQIOther>>> GetQualityPQIOther(string Plant)
        {
            return await _context.QualityPQIOther.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        // GET: api/PQIOther/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PQIOther>> GetPQIOther(int id)
        {
            var PQIOther = await _context.QualityPQIOther.FindAsync(id);

            if (PQIOther == null)
            {
                return NotFound();
            }

            return PQIOther;
        }

        // PUT: api/PQIOther/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPQIOther(int id, PQIOther PQIOther)
        {
            if (id != PQIOther.Id)
            {
                return BadRequest();
            }

            PQIOther.Modified = DateTime.Now;
            //_context.Entry(PQIOther).State = EntityState.Modified;
            _context.Attach(PQIOther);

            var entry = _context.Entry(PQIOther);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //_context.Entry(PQIOther).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PQIOtherExists(id))
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

        // POST: api/PQIOther
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PQIOther>> PostPQIOther(PQIOther PQIOther)
        {
            PQIOther.Created = DateTime.Now;
            PQIOther.Modified = PQIOther.Created;
            _context.QualityPQIOther.Add(PQIOther);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPQIOther", new { id = PQIOther.Id }, PQIOther);
        }

        // DELETE: api/PQIOther/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PQIOther>> DeletePQIOther(int id)
        {
            var PQIOther = await _context.QualityPQIOther.FindAsync(id);
            if (PQIOther == null)
            {
                return NotFound();
            }

            _context.QualityPQIOther.Remove(PQIOther);
            await _context.SaveChangesAsync();

            return PQIOther;
        }

        private bool PQIOtherExists(int id)
        {
            return _context.QualityPQIOther.Any(e => e.Id == id);
        }
    }
}
