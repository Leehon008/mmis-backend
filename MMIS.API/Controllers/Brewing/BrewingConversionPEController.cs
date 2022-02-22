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



    public class BrewingConversionPEController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingConversionPEController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingConversionPE
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ConversionPE>>> GetBrewingConversionPE()
        //{
        //    return await _context.BrewingConversionPE.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConversionPE>>> GetBrewingConversionPE(string Plant)
        {
            return await _context.BrewingConversionPE.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingConversionPE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConversionPE>> GetConversionPE(int id)
        {
            var conversionPE = await _context.BrewingConversionPE.FindAsync(id);

            if (conversionPE == null)
            {
                return NotFound();
            }

            return conversionPE;
        }

        // PUT: api/BrewingConversionPE/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversionPE(int id, ConversionPE conversionPE)
        {
            if (id != conversionPE.Id)
            {
                return BadRequest();
            }
            conversionPE.Modified = DateTime.Now;
            _context.Entry(conversionPE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversionPEExists(id))
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

        // POST: api/BrewingConversionPE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConversionPE>> PostConversionPE(ConversionPE conversionPE)
        {
            conversionPE.Created = DateTime.Now;
            conversionPE.Modified = DateTime.Now;
            _context.BrewingConversionPE.Add(conversionPE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConversionPE", new { id = conversionPE.Id }, conversionPE);
        }

        // DELETE: api/BrewingConversionPE/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConversionPE>> DeleteConversionPE(int id)
        {
            var conversionPE = await _context.BrewingConversionPE.FindAsync(id);
            if (conversionPE == null)
            {
                return NotFound();
            }

            _context.BrewingConversionPE.Remove(conversionPE);
            await _context.SaveChangesAsync();

            return conversionPE;
        }

        private bool ConversionPEExists(int id)
        {
            return _context.BrewingConversionPE.Any(e => e.Id == id);
        }
    }
}
