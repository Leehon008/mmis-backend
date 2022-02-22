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

    public class PQIOtherScudController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PQIOtherScudController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PQIOtherScud
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PQIOtherScud>>> GetQualityPQIOtherScud()
        //{
        //    return await _context.QualityPQIOtherScud.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PQIOtherScud>>> GetQualityPQIOtherScud(string Plant)
        {
            return await _context.QualityPQIOtherScud.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        // GET: api/PQIOtherScud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PQIOtherScud>> GetPQIOtherScud(int id)
        {
            var PQIOtherScud = await _context.QualityPQIOtherScud.FindAsync(id);

            if (PQIOtherScud == null)
            {
                return NotFound();
            }

            return PQIOtherScud;
        }

        // PUT: api/PQIOtherScud/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPQIOtherScud(int id, PQIOtherScud PQIOtherScud)
        {
            if (id != PQIOtherScud.Id)
            {
                return BadRequest();
            }

            PQIOtherScud.Modified = DateTime.Now;
            //_context.Entry(PQIOtherScud).State = EntityState.Modified;
            _context.Attach(PQIOtherScud);

            var entry = _context.Entry(PQIOtherScud);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //_context.Entry(PQIOtherScud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PQIOtherScudExists(id))
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

        // POST: api/PQIOtherScud
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PQIOtherScud>> PostPQIOtherScud(PQIOtherScud PQIOtherScud)
        {
            PQIOtherScud.Created = DateTime.Now;
            PQIOtherScud.Modified = PQIOtherScud.Created;
            _context.QualityPQIOtherScud.Add(PQIOtherScud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPQIOtherScud", new { id = PQIOtherScud.Id }, PQIOtherScud);
        }

        // DELETE: api/PQIOtherScud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PQIOtherScud>> DeletePQIOtherScud(int id)
        {
            var PQIOtherScud = await _context.QualityPQIOtherScud.FindAsync(id);
            if (PQIOtherScud == null)
            {
                return NotFound();
            }

            _context.QualityPQIOtherScud.Remove(PQIOtherScud);
            await _context.SaveChangesAsync();

            return PQIOtherScud;
        }

        private bool PQIOtherScudExists(int id)
        {
            return _context.QualityPQIOtherScud.Any(e => e.Id == id);
        }
    }
}
