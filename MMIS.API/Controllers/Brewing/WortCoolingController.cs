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



    public class WortCoolingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public WortCoolingController(MMISDbContext context)
        {
            _context = context;
        }

      


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WortCooling>>> GetBrewingWortCooling(string Plant)
        {
            return await _context.BrewingWortCooling.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/WortCooling/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WortCooling>> GetWortCooling(int id)
        {
            var wortCooling = await _context.BrewingWortCooling.FindAsync(id);

            if (wortCooling == null)
            {
                return NotFound();
            }

            return wortCooling;
        }

        // PUT: api/WortCooling/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWortCooling(int id, WortCooling wortCooling)
        {
            if (id != wortCooling.Id)
            {
                return BadRequest();
            }
            wortCooling.Modified = DateTime.Now;
            _context.Entry(wortCooling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WortCoolingExists(id))
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

        // POST: api/WortCooling
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WortCooling>> PostWortCooling(WortCooling wortCooling)
        {
            wortCooling.Created = DateTime.Now;
            wortCooling.Modified = DateTime.Now;
            _context.BrewingWortCooling.Add(wortCooling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWortCooling", new { id = wortCooling.Id }, wortCooling);
        }

        // DELETE: api/WortCooling/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WortCooling>> DeleteWortCooling(int id)
        {
            var wortCooling = await _context.BrewingWortCooling.FindAsync(id);
            if (wortCooling == null)
            {
                return NotFound();
            }

            _context.BrewingWortCooling.Remove(wortCooling);
            await _context.SaveChangesAsync();

            return wortCooling;
        }

        private bool WortCoolingExists(int id)
        {
            return _context.BrewingWortCooling.Any(e => e.Id == id);
        }
    }
}
