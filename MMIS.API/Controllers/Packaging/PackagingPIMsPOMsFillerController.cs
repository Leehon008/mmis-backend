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

    public class PackagingPIMsPOMsFillerController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMsFillerController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMsFillers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMsFiller>>> GetPIMsPOMsFiller()
        {
            return await _context.PIMsPOMsFiller.ToListAsync();
        }

        // GET: api/PIMsPOMsFillers/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMsFiller>>> GetPIMsPOMsFiller(string ShiftNo)
        {
            var PIMsPOMsFiller = await _context.PIMsPOMsFiller.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMsFiller == null)
            {
                return NotFound();
            }

            return PIMsPOMsFiller;
        }

        // GET: api/PIMsPOMsFillers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMsFiller>> GetPIMsPOMsFiller(int id)
        {
            var PIMsPOMsFiller = await _context.PIMsPOMsFiller.FindAsync(id);

            if (PIMsPOMsFiller == null)
            {
                return NotFound();
            }

            return PIMsPOMsFiller;
        }

        // PUT: api/PIMsPOMsFillers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMsFiller(int id, PIMsPOMsFiller PIMsPOMsFiller)
        {
            if (id != PIMsPOMsFiller.Id)
            {
                return BadRequest();
            }
            //PIMsPOMsFiller. = DateTime.Now;

            _context.Entry(PIMsPOMsFiller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMsFillerExists(id))
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

        // POST: api/PIMsPOMsFillers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMsFiller>> PostPIMsPOMsFiller(List<PIMsPOMsFiller> PIMsPOMsFiller)
        {
            foreach (var PIMsPOMsFillerData in PIMsPOMsFiller)
            {
                _context.PIMsPOMsFiller.Add(PIMsPOMsFillerData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMsFiller", new { PIMsPOMsFiller });
 
        }

        // DELETE: api/PIMsPOMsFillers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMsFiller>> DeletePIMsPOMsFiller(int id)
        {
            var PIMsPOMsFiller = await _context.PIMsPOMsFiller.FindAsync(id);
            if (PIMsPOMsFiller == null)
            {
                return NotFound();
            }

            _context.PIMsPOMsFiller.Remove(PIMsPOMsFiller);
            await _context.SaveChangesAsync();

            return PIMsPOMsFiller;
        }

        private bool PIMsPOMsFillerExists(int id)
        {
            return _context.PIMsPOMsFiller.Any(e => e.Id == id);
        }
    }
}
