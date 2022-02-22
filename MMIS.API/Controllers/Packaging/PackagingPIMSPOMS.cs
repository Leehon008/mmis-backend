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

    public class PackagingPIMsPOMsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMs>>> GetPIMsPOMs()
        {
            return await _context.PIMsPOMs.ToListAsync();
        }

        // GET: api/PIMsPOMss/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMs>>> GetPIMsPOMs(string ShiftNo)
        {
            var PIMsPOMs = await _context.PIMsPOMs.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMs == null)
            {
                return NotFound();
            }

            return PIMsPOMs;
        }

        // GET: api/PIMsPOMss/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMs>> GetPIMsPOMs(int id)
        {
            var PIMsPOMs = await _context.PIMsPOMs.FindAsync(id);

            if (PIMsPOMs == null)
            {
                return NotFound();
            }

            return PIMsPOMs;
        }

        // PUT: api/PIMsPOMss/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMs(int id, PIMsPOMs PIMsPOMs)
        {
            if (id != PIMsPOMs.Id)
            {
                return BadRequest();
            }
            //PIMsPOMs. = DateTime.Now;

            _context.Entry(PIMsPOMs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMsExists(id))
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

        // POST: api/PIMsPOMss
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMs>> PostPIMsPOMs(List<PIMsPOMs> PIMsPOMs)
        {
            foreach (var PIMsPOMsData in PIMsPOMs)
            {
                _context.PIMsPOMs.Add(PIMsPOMsData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMs", new { PIMsPOMs });
 
        }

        // DELETE: api/PIMsPOMss/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMs>> DeletePIMsPOMs(int id)
        {
            var PIMsPOMs = await _context.PIMsPOMs.FindAsync(id);
            if (PIMsPOMs == null)
            {
                return NotFound();
            }

            _context.PIMsPOMs.Remove(PIMsPOMs);
            await _context.SaveChangesAsync();

            return PIMsPOMs;
        }

        private bool PIMsPOMsExists(int id)
        {
            return _context.PIMsPOMs.Any(e => e.Id == id);
        }
    }
}
