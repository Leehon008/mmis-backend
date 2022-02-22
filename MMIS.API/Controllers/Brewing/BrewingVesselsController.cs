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

    public class BrewingVesselsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingVesselsController(MMISDbContext context)
        {
            _context = context;
        }

        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<BrewingVessels>>> GetBrewingVessels(string Plant)
        {
            return await _context.BrewingVessels.Where(x=>x.Plant.Trim()==Plant.Trim()).ToListAsync();
        }
     
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewingVessels(int id, BrewingVessels brewingVessels)
        {
            if (id != brewingVessels.Id)
            {
                return BadRequest();
            }
            brewingVessels.Modified = DateTime.Now;
            _context.Entry(brewingVessels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewingVesselsExists(id))
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

        // POST: api/BrewingVessels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewingVessels>> PostBrewingVessels(BrewingVessels brewingVessels)
        {
            brewingVessels.Modified = DateTime.Now;
            brewingVessels.Created = DateTime.Now;
            _context.BrewingVessels.Add(brewingVessels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewingVessels", new { id = brewingVessels.Id }, brewingVessels);
        }

        // DELETE: api/BrewingVessels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrewingVessels>> DeleteBrewingVessels(int id)
        {
            var brewingVessels = await _context.BrewingVessels.FindAsync(id);
            if (brewingVessels == null)
            {
                return NotFound();
            }

            _context.BrewingVessels.Remove(brewingVessels);
            await _context.SaveChangesAsync();

            return brewingVessels;
        }

        private bool BrewingVesselsExists(int id)
        {
            return _context.BrewingVessels.Any(e => e.Id == id);
        }
    }
}
