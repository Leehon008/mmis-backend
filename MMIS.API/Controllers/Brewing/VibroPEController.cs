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



    public class VibroPEController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public VibroPEController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/VibroPE
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VibroPE>>> GetBrewingVibroPE()
        //{
        //    return await _context.BrewingVibroPE.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VibroPE>>> GetBrewingVibroPE(string Plant)
        {
            return await _context.BrewingVibroPE.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/VibroPE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VibroPE>> GetVibroPE(int id)
        {
            var vibroPE = await _context.BrewingVibroPE.FindAsync(id);

            if (vibroPE == null)
            {
                return NotFound();
            }

            return vibroPE;
        }

        // PUT: api/VibroPE/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVibroPE(int id, VibroPE vibroPE)
        {
            if (id != vibroPE.Id)
            {
                return BadRequest();
            }

            vibroPE.Modified = DateTime.Now;
            _context.Entry(vibroPE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VibroPEExists(id))
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

        // POST: api/VibroPE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VibroPE>> PostVibroPE(VibroPE vibroPE)
        {
            vibroPE.Created = DateTime.Now;
            vibroPE.Modified = DateTime.Now;
            _context.BrewingVibroPE.Add(vibroPE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVibroPE", new { id = vibroPE.Id }, vibroPE);
        }

        // DELETE: api/VibroPE/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VibroPE>> DeleteVibroPE(int id)
        {
            var vibroPE = await _context.BrewingVibroPE.FindAsync(id);
            if (vibroPE == null)
            {
                return NotFound();
            }

            _context.BrewingVibroPE.Remove(vibroPE);
            await _context.SaveChangesAsync();

            return vibroPE;
        }

        private bool VibroPEExists(int id)
        {
            return _context.BrewingVibroPE.Any(e => e.Id == id);
        }
    }
}
