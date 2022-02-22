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

    public class PackagingPIMsPOMsBlowMoulderController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMsBlowMoulderController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMsBlowMoulders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMsBlowMoulder>>> GetPIMsPOMsBlowMoulder()
        {
            return await _context.PIMsPOMsBlowMoulder.ToListAsync();
        }

        // GET: api/PIMsPOMsBlowMoulders/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMsBlowMoulder>>> GetPIMsPOMsBlowMoulder(string ShiftNo)
        {
            var PIMsPOMsBlowMoulder = await _context.PIMsPOMsBlowMoulder.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMsBlowMoulder == null)
            {
                return NotFound();
            }

            return PIMsPOMsBlowMoulder;
        }

        // GET: api/PIMsPOMsBlowMoulders/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMsBlowMoulder>> GetPIMsPOMsBlowMoulder(int id)
        {
            var PIMsPOMsBlowMoulder = await _context.PIMsPOMsBlowMoulder.FindAsync(id);

            if (PIMsPOMsBlowMoulder == null)
            {
                return NotFound();
            }

            return PIMsPOMsBlowMoulder;
        }

        // PUT: api/PIMsPOMsBlowMoulders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMsBlowMoulder(int id, PIMsPOMsBlowMoulder PIMsPOMsBlowMoulder)
        {
            if (id != PIMsPOMsBlowMoulder.Id)
            {
                return BadRequest();
            }
            //PIMsPOMsBlowMoulder. = DateTime.Now;

            _context.Entry(PIMsPOMsBlowMoulder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMsBlowMoulderExists(id))
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

        // POST: api/PIMsPOMsBlowMoulders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMsBlowMoulder>> PostPIMsPOMsBlowMoulder(List<PIMsPOMsBlowMoulder> PIMsPOMsBlowMoulder)
        {
            foreach (var PIMsPOMsBlowMoulderData in PIMsPOMsBlowMoulder)
            {
                _context.PIMsPOMsBlowMoulder.Add(PIMsPOMsBlowMoulderData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMsBlowMoulder", new { PIMsPOMsBlowMoulder });
 
        }

        // DELETE: api/PIMsPOMsBlowMoulders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMsBlowMoulder>> DeletePIMsPOMsBlowMoulder(int id)
        {
            var PIMsPOMsBlowMoulder = await _context.PIMsPOMsBlowMoulder.FindAsync(id);
            if (PIMsPOMsBlowMoulder == null)
            {
                return NotFound();
            }

            _context.PIMsPOMsBlowMoulder.Remove(PIMsPOMsBlowMoulder);
            await _context.SaveChangesAsync();

            return PIMsPOMsBlowMoulder;
        }

        private bool PIMsPOMsBlowMoulderExists(int id)
        {
            return _context.PIMsPOMsBlowMoulder.Any(e => e.Id == id);
        }
    }
}
