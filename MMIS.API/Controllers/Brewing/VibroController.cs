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



    public class VibroController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public VibroController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Vibro
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Vibro>>> GetBrewingVibro()
        //{
        //    return await _context.BrewingVibro.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vibro>>> GetBrewingVibro(string Plant)
        {
            return await _context.BrewingVibro.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Vibro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vibro>> GetVibro(int id)
        {
            var vibro = await _context.BrewingVibro.FindAsync(id);

            if (vibro == null)
            {
                return NotFound();
            }

            return vibro;
        }

        // PUT: api/Vibro/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVibro(int id, Vibro vibro)
        {
            if (id != vibro.Id)
            {
                return BadRequest();
            }

            vibro.Modified = DateTime.Now;
            _context.Entry(vibro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VibroExists(id))
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

        // POST: api/Vibro
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vibro>> PostVibro(Vibro vibro)
        {
            vibro.Created = DateTime.Now;
            vibro.Modified = DateTime.Now;
            _context.BrewingVibro.Add(vibro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVibro", new { id = vibro.Id }, vibro);
        }

        // DELETE: api/Vibro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vibro>> DeleteVibro(int id)
        {
            var vibro = await _context.BrewingVibro.FindAsync(id);
            if (vibro == null)
            {
                return NotFound();
            }

            _context.BrewingVibro.Remove(vibro);
            await _context.SaveChangesAsync();

            return vibro;
        }

        private bool VibroExists(int id)
        {
            return _context.BrewingVibro.Any(e => e.Id == id);
        }
    }
}
