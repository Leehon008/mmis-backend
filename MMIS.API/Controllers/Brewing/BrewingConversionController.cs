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



    public class BrewingConversionController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingConversionController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingConversion
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Conversion>>> GetBrewingConversions()
        //{
        //    return await _context.BrewingConversions.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversion>>> GetBrewingConversions(string Plant)
        {
            return await _context.BrewingConversions.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingConversion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conversion>> GetConversion(int id)
        {
            var conversion = await _context.BrewingConversions.FindAsync(id);

            if (conversion == null)
            {
                return NotFound();
            }

            return conversion;
        }

        // PUT: api/BrewingConversion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversion(int id, Conversion conversion)
        {
            if (id != conversion.Id)
            {
                return BadRequest();
            }
            conversion.Modified = DateTime.Now;
            _context.Entry(conversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversionExists(id))
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

        // POST: api/BrewingConversion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Conversion>> PostConversion(Conversion conversion)
        {
            conversion.Created = DateTime.Now;
            conversion.Modified = DateTime.Now;
            _context.BrewingConversions.Add(conversion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConversion", new { id = conversion.Id }, conversion);
        }

        // DELETE: api/BrewingConversion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conversion>> DeleteConversion(int id)
        {
            var conversion = await _context.BrewingConversions.FindAsync(id);
            if (conversion == null)
            {
                return NotFound();
            }

            _context.BrewingConversions.Remove(conversion);
            await _context.SaveChangesAsync();

            return conversion;
        }

        private bool ConversionExists(int id)
        {
            return _context.BrewingConversions.Any(e => e.Id == id);
        }
    }
}
