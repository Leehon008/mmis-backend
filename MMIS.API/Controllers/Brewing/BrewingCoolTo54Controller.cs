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



    public class BrewingCoolTo54Controller : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingCoolTo54Controller(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingCoolTo54
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CoolTo54>>> GetBrewingCoolTo54()
        //{
        //    return await _context.BrewingCoolTo54.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoolTo54>>> GetBrewingCoolTo54(string Plant)
        {
            return await _context.BrewingCoolTo54.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingCoolTo54/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoolTo54>> GetCoolTo54(int id)
        {
            var conversion = await _context.BrewingCoolTo54.FindAsync(id);

            if (conversion == null)
            {
                return NotFound();
            }

            return conversion;
        }

        // PUT: api/BrewingCoolTo54/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoolTo54(int id, CoolTo54 conversion)
        {
            if (id != conversion.Id)
            {
                return BadRequest();
            }
         //   conversion.Created = DateTime.Now;
            conversion.Modified = DateTime.Now;
            _context.Entry(conversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoolTo54Exists(id))
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

        // POST: api/BrewingCoolTo54
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CoolTo54>> PostCoolTo54(CoolTo54 conversion)
        {
            conversion.Created = DateTime.Now;
            conversion.Modified = DateTime.Now;
            _context.BrewingCoolTo54.Add(conversion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoolTo54", new { id = conversion.Id }, conversion);
        }

        // DELETE: api/BrewingCoolTo54/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoolTo54>> DeleteCoolTo54(int id)
        {
            var conversion = await _context.BrewingCoolTo54.FindAsync(id);
            if (conversion == null)
            {
                return NotFound();
            }

            _context.BrewingCoolTo54.Remove(conversion);
            await _context.SaveChangesAsync();

            return conversion;
        }

        private bool CoolTo54Exists(int id)
        {
            return _context.BrewingCoolTo54.Any(e => e.Id == id);
        }
    }
}
