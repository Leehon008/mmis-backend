using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

    //[Authorize]
    public class EndMillingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public EndMillingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/EndMilling
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EndMilling>>> GetBrewingEndMilling()
        //{
        //    return await _context.BrewingEndMilling.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EndMilling>>> GetBrewingEndMilling(string Plant)
        {
            return await _context.BrewingEndMilling.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/EndMilling/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EndMilling>> GetEndMilling(int id)
        {
            var endMilling = await _context.BrewingEndMilling.FindAsync(id);

            if (endMilling == null)
            {
                return NotFound();
            }

            return endMilling;
        }

        // PUT: api/EndMilling/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndMilling(int id, EndMilling endMilling)
        {
            if (id != endMilling.Id)
            {
                return BadRequest();
            }

            _context.Entry(endMilling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EndMillingExists(id))
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

        // POST: api/EndMilling
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EndMilling>> PostEndMilling(EndMilling endMilling)
        {
            _context.BrewingEndMilling.Add(endMilling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndMilling", new { id = endMilling.Id }, endMilling);
        }

        // DELETE: api/EndMilling/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EndMilling>> DeleteEndMilling(int id)
        {
            var endMilling = await _context.BrewingEndMilling.FindAsync(id);
            if (endMilling == null)
            {
                return NotFound();
            }

            _context.BrewingEndMilling.Remove(endMilling);
            await _context.SaveChangesAsync();

            return endMilling;
        }

        private bool EndMillingExists(int id)
        {
            return _context.BrewingEndMilling.Any(e => e.Id == id);
        }
    }
}
