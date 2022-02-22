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



    public class StrainingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public StrainingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Straining
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Strain>>> GetBrewingStrain()
        //{
        //    return await _context.BrewingStrain.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Strain>>> GetBrewingStrain(string Plant)
        {
            return await _context.BrewingStrain.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Straining/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Strain>> GetStrain(int id)
        {
            var strain = await _context.BrewingStrain.FindAsync(id);

            if (strain == null)
            {
                return NotFound();
            }

            return strain;
        }

        // PUT: api/Straining/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrain(int id, Strain strain)
        {
            if (id != strain.Id)
            {
                return BadRequest();
            }
            strain.Modified = DateTime.Now;
            _context.Entry(strain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrainExists(id))
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

        // POST: api/Straining
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Strain>> PostStrain(Strain strain)
        {
            strain.Created = DateTime.Now;
            strain.Modified = DateTime.Now;
            _context.BrewingStrain.Add(strain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrain", new { id = strain.Id }, strain);
        }

        // DELETE: api/Straining/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Strain>> DeleteStrain(int id)
        {
            var strain = await _context.BrewingStrain.FindAsync(id);
            if (strain == null)
            {
                return NotFound();
            }

            _context.BrewingStrain.Remove(strain);
            await _context.SaveChangesAsync();

            return strain;
        }

        private bool StrainExists(int id)
        {
            return _context.BrewingStrain.Any(e => e.Id == id);
        }
    }
}
