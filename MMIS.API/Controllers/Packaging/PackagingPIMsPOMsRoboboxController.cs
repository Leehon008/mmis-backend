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

    public class PackagingPIMsPOMsRoboboxController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMsRoboboxController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMsRoboboxs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMsRobobox>>> GetPIMsPOMsRobobox()
        {
            return await _context.PIMsPOMsRobobox.ToListAsync();
        }

        // GET: api/PIMsPOMsRoboboxs/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMsRobobox>>> GetPIMsPOMsRobobox(string ShiftNo)
        {
            var PIMsPOMsRobobox = await _context.PIMsPOMsRobobox.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMsRobobox == null)
            {
                return NotFound();
            }

            return PIMsPOMsRobobox;
        }

        // GET: api/PIMsPOMsRoboboxs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMsRobobox>> GetPIMsPOMsRobobox(int id)
        {
            var PIMsPOMsRobobox = await _context.PIMsPOMsRobobox.FindAsync(id);

            if (PIMsPOMsRobobox == null)
            {
                return NotFound();
            }

            return PIMsPOMsRobobox;
        }

        // PUT: api/PIMsPOMsRoboboxs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMsRobobox(int id, PIMsPOMsRobobox PIMsPOMsRobobox)
        {
            if (id != PIMsPOMsRobobox.Id)
            {
                return BadRequest();
            }
            //PIMsPOMsRobobox. = DateTime.Now;

            _context.Entry(PIMsPOMsRobobox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMsRoboboxExists(id))
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

        // POST: api/PIMsPOMsRoboboxs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMsRobobox>> PostPIMsPOMsRobobox(List<PIMsPOMsRobobox> PIMsPOMsRobobox)
        {
            foreach (var PIMsPOMsRoboboxData in PIMsPOMsRobobox)
            {
                _context.PIMsPOMsRobobox.Add(PIMsPOMsRoboboxData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMsRobobox", new { PIMsPOMsRobobox });
 
        }

        // DELETE: api/PIMsPOMsRoboboxs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMsRobobox>> DeletePIMsPOMsRobobox(int id)
        {
            var PIMsPOMsRobobox = await _context.PIMsPOMsRobobox.FindAsync(id);
            if (PIMsPOMsRobobox == null)
            {
                return NotFound();
            }

            _context.PIMsPOMsRobobox.Remove(PIMsPOMsRobobox);
            await _context.SaveChangesAsync();

            return PIMsPOMsRobobox;
        }

        private bool PIMsPOMsRoboboxExists(int id)
        {
            return _context.PIMsPOMsRobobox.Any(e => e.Id == id);
        }
    }
}
