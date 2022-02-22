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

    public class BrewerShiftHandOverController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewerShiftHandOverController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewerShiftHandOver
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrewerShiftHandOver>>> GetBrewerShiftHandOver()
        {
            return await _context.BrewerShiftHandOver.ToListAsync();
        }

        // GET: api/BrewerShiftHandOver/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrewerShiftHandOver>> GetBrewerShiftHandOver(int id)
        {
            var brewerShiftHandOver = await _context.BrewerShiftHandOver.FindAsync(id);

            if (brewerShiftHandOver == null)
            {
                return NotFound();
            }

            return brewerShiftHandOver;
        }

        // PUT: api/BrewerShiftHandOver/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewerShiftHandOver(int id, BrewerShiftHandOver brewerShiftHandOver)
        {
            brewerShiftHandOver.DateModified = DateTime.Now;
            if (id != brewerShiftHandOver.Id)
            {
                return BadRequest();
            }

            _context.Entry(brewerShiftHandOver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewerShiftHandOverExists(id))
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

        // POST: api/BrewerShiftHandOver
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewerShiftHandOver>> PostBrewerShiftHandOver(BrewerShiftHandOver brewerShiftHandOver)
        {
            brewerShiftHandOver.DateModified = DateTime.Now;
            brewerShiftHandOver.DateCreated = DateTime.Now;
            _context.BrewerShiftHandOver.Add(brewerShiftHandOver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewerShiftHandOver", new { id = brewerShiftHandOver.Id }, brewerShiftHandOver);
        }

        // DELETE: api/BrewerShiftHandOver/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrewerShiftHandOver>> DeleteBrewerShiftHandOver(int id)
        {
            var brewerShiftHandOver = await _context.BrewerShiftHandOver.FindAsync(id);
            if (brewerShiftHandOver == null)
            {
                return NotFound();
            }

            _context.BrewerShiftHandOver.Remove(brewerShiftHandOver);
            await _context.SaveChangesAsync();

            return brewerShiftHandOver;
        }

        private bool BrewerShiftHandOverExists(int id)
        {
            return _context.BrewerShiftHandOver.Any(e => e.Id == id);
        }
    }
}
