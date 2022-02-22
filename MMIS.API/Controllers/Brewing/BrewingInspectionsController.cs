using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Brewing.Entities;

namespace MMIS.API.Controllers.Brewing
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class BrewingInspectionsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingInspectionsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingInspections
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Inspection>>> GetBrewingInspections()
        //{
        //    return await _context.BrewingInspections.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspection>>> GetBrewingInspections(string Plant)
        {
            return await _context.BrewingInspections.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspection>> GetInspection(int id)
        {
            var inspection = await _context.BrewingInspections.FindAsync(id);

            if (inspection == null)
            {
                return NotFound();
            }

            return inspection;
        }

        // PUT: api/BrewingInspections/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspection(int id, Inspection inspection)
        {
            if (id != inspection.Id)
            {
                return BadRequest();
            }
            inspection.Modified = DateTime.Now;
            _context.Entry(inspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
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

        // POST: api/BrewingInspections
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inspection>> PostInspection(Inspection inspection)
        {
            inspection.Created = DateTime.Now;
            inspection.Modified = DateTime.Now;
            _context.BrewingInspections.Add(inspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspection", new { id = inspection.Id }, inspection);
        }

        // DELETE: api/BrewingInspections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inspection>> DeleteInspection(int id)
        {
            var inspection = await _context.BrewingInspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }

            _context.BrewingInspections.Remove(inspection);
            await _context.SaveChangesAsync();

            return inspection;
        }

        private bool InspectionExists(int id)
        {
            return _context.BrewingInspections.Any(e => e.Id == id);
        }
    }
}
