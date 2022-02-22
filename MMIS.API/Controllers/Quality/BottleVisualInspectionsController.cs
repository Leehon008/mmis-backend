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

    public class BottleVisualInspectionsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BottleVisualInspectionsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BottleVisualInspections
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BottleVisualInspection>>> GetQualityBottleVisualInspection()
        //{
        //    return await _context.QualityBottleVisualInspection.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BottleVisualInspection>>> GetQualityBottleVisualInspection(string Plant)
        {
            return await _context.QualityBottleVisualInspection.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BottleVisualInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BottleVisualInspection>> GetBottleVisualInspection(int id)
        {
            var BottleVisualInspection = await _context.QualityBottleVisualInspection.FindAsync(id);

            if (BottleVisualInspection == null)
            {
                return NotFound();
            }

            return BottleVisualInspection;
        }

        // PUT: api/BottleVisualInspections/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBottleVisualInspection(int id, BottleVisualInspection BottleVisualInspection)
        {
            if (id != BottleVisualInspection.Id)
            {
                return BadRequest();
            }

            BottleVisualInspection.Modified = DateTime.Now;
            //_context.Entry(BottleVisualInspection).State = EntityState.Modified;
            _context.Attach(BottleVisualInspection);

            var entry = _context.Entry(BottleVisualInspection);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //_context.Entry(BottleVisualInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BottleVisualInspectionExists(id))
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

        // POST: api/BottleVisualInspections
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BottleVisualInspection>> PostBottleVisualInspection(BottleVisualInspection BottleVisualInspection)
        {
            BottleVisualInspection.Created = DateTime.Now;
            BottleVisualInspection.Modified = BottleVisualInspection.Created;
            _context.QualityBottleVisualInspection.Add(BottleVisualInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBottleVisualInspection", new { id = BottleVisualInspection.Id }, BottleVisualInspection);
        }

        // DELETE: api/BottleVisualInspections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BottleVisualInspection>> DeleteBottleVisualInspection(int id)
        {
            var BottleVisualInspection = await _context.QualityBottleVisualInspection.FindAsync(id);
            if (BottleVisualInspection == null)
            {
                return NotFound();
            }

            _context.QualityBottleVisualInspection.Remove(BottleVisualInspection);
            await _context.SaveChangesAsync();

            return BottleVisualInspection;
        }

        private bool BottleVisualInspectionExists(int id)
        {
            return _context.QualityBottleVisualInspection.Any(e => e.Id == id);
        }
    }
}
