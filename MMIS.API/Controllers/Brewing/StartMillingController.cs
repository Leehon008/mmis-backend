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
    public class StartMillingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public StartMillingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/StartMilling
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StartMilling>>> GetBrewingStartMilling()
        //{
        //    return await _context.BrewingStartMilling.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StartMilling>>> GetBrewingStartMilling(string Plant)
        {
            return await _context.BrewingStartMilling.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/StartMilling/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StartMilling>> GetStartMilling(int id)
        {
            var startMilling = await _context.BrewingStartMilling.FindAsync(id);

            if (startMilling == null)
            {
                return NotFound();
            }

            return startMilling;
        }

        // PUT: api/StartMilling/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStartMilling(int id, StartMilling startMilling)
        {
            if (id != startMilling.Id)
            {
                return BadRequest();
            }
            startMilling.Modified = DateTime.Now;
            _context.Entry(startMilling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StartMillingExists(id))
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

        // POST: api/StartMilling
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StartMilling>> PostStartMilling(StartMilling startMilling)
        {
            startMilling.Created = DateTime.Now;
            startMilling.Modified = DateTime.Now;
            _context.BrewingStartMilling.Add(startMilling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStartMilling", new { id = startMilling.Id }, startMilling);
        }

        // DELETE: api/StartMilling/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StartMilling>> DeleteStartMilling(int id)
        {
            var startMilling = await _context.BrewingStartMilling.FindAsync(id);
            if (startMilling == null)
            {
                return NotFound();
            }

            _context.BrewingStartMilling.Remove(startMilling);
            await _context.SaveChangesAsync();

            return startMilling;
        }

        private bool StartMillingExists(int id)
        {
            return _context.BrewingStartMilling.Any(e => e.Id == id);
        }
    }
}
