using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class PackagingInspectionsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingInspectionsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Inspectionss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspections>>> GetInspections()
        {
            return await _context.Inspections.ToListAsync();
        }

        // GET: api/Inspectionss/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<Inspections>>> GetInspections(string ShiftNo)
        {
            var Inspections = await _context.Inspections.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (Inspections == null)
            {
                return NotFound();
            }

            return Inspections;
        }

        // GET: api/Inspectionss/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Inspections>> GetInspections(int id)
        {
            var Inspections = await _context.Inspections.FindAsync(id);

            if (Inspections == null)
            {
                return NotFound();
            }

            return Inspections;
        }

        // PUT: api/Inspectionss/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspections(int id, Inspections Inspections)
        {
            if (id != Inspections.Id)
            {
                return BadRequest();
            }
            //Inspections. = DateTime.Now;

            _context.Entry(Inspections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionsExists(id))
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

        // POST: api/Inspectionss
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inspections>> PostInspections(List<Inspections> Inspections)
        {
            foreach (var InspectionsData in Inspections)
            {
                _context.Inspections.Add(InspectionsData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetInspections", new { Inspections });
 
        }

        // DELETE: api/Inspectionss/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inspections>> DeleteInspections(int id)
        {
            var Inspections = await _context.Inspections.FindAsync(id);
            if (Inspections == null)
            {
                return NotFound();
            }

            _context.Inspections.Remove(Inspections);
            await _context.SaveChangesAsync();

            return Inspections;
        }

        private bool InspectionsExists(int id)
        {
            return _context.Inspections.Any(e => e.Id == id);
        }
    }
}
