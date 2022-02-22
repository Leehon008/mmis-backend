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

    public class BrewingPAShiftHandOverController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingPAShiftHandOverController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingPAShiftHandOver
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BrewingPAShiftHandOver>>> GetBrewingPAShiftHandOver()
        //{
        //    return await _context.BrewingPAShiftHandOver.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrewingPAShiftHandOver>>> GetBrewingPAShiftHandOver(string Plant)
        {
            return await _context.BrewingPAShiftHandOver.ToListAsync();
        }

        // GET: api/BrewingPAShiftHandOver/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrewingPAShiftHandOver>> GetBrewingPAShiftHandOver(int id)
        {
            var brewingPAShiftHandOver = await _context.BrewingPAShiftHandOver.FindAsync(id);

            if (brewingPAShiftHandOver == null)
            {
                return NotFound();
            }

            return brewingPAShiftHandOver;
        }

        // PUT: api/BrewingPAShiftHandOver/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewingPAShiftHandOver(int id, BrewingPAShiftHandOver brewingPAShiftHandOver)
        {
            if (id != brewingPAShiftHandOver.Id)
            {
                return BadRequest();
            }
            brewingPAShiftHandOver.DateModified = DateTime.Now;
            _context.Entry(brewingPAShiftHandOver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewingPAShiftHandOverExists(id))
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

        // POST: api/BrewingPAShiftHandOver
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewingPAShiftHandOver>> PostBrewingPAShiftHandOver(BrewingPAShiftHandOver brewingPAShiftHandOver)
        {
            brewingPAShiftHandOver.DateModified = DateTime.Now;
            brewingPAShiftHandOver.DateCreated = DateTime.Now;
            _context.BrewingPAShiftHandOver.Add(brewingPAShiftHandOver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewingPAShiftHandOver", new { id = brewingPAShiftHandOver.Id }, brewingPAShiftHandOver);
        }

        // DELETE: api/BrewingPAShiftHandOver/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrewingPAShiftHandOver>> DeleteBrewingPAShiftHandOver(int id)
        {
            var brewingPAShiftHandOver = await _context.BrewingPAShiftHandOver.FindAsync(id);
            if (brewingPAShiftHandOver == null)
            {
                return NotFound();
            }

            _context.BrewingPAShiftHandOver.Remove(brewingPAShiftHandOver);
            await _context.SaveChangesAsync();

            return brewingPAShiftHandOver;
        }

        private bool BrewingPAShiftHandOverExists(int id)
        {
            return _context.BrewingPAShiftHandOver.Any(e => e.Id == id);
        }
    }
}
