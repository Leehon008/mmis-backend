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



    public class WortCoolingPEController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public WortCoolingPEController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/WortCoolingPE
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WortCoolingPE>>> GetBrewingWortCoolingPE()
        //{
        //    return await _context.BrewingWortCoolingPE.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WortCoolingPE>>> GetBrewingWortCoolingPE(string Plant)
        {
            return await _context.BrewingWortCoolingPE.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/WortCoolingPE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WortCoolingPE>> GetWortCoolingPE(int id)
        {
            var wortCoolingPE = await _context.BrewingWortCoolingPE.FindAsync(id);

            if (wortCoolingPE == null)
            {
                return NotFound();
            }

            return wortCoolingPE;
        }

        // PUT: api/WortCoolingPE/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWortCoolingPE(int id, WortCoolingPE wortCoolingPE)
        {
            if (id != wortCoolingPE.Id)
            {
                return BadRequest();
            }

            wortCoolingPE.Modified = DateTime.Now;
            _context.Entry(wortCoolingPE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WortCoolingPEExists(id))
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

        // POST: api/WortCoolingPE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WortCoolingPE>> PostWortCoolingPE(WortCoolingPE wortCoolingPE)
        {
            wortCoolingPE.Created = DateTime.Now;
            wortCoolingPE.Modified = DateTime.Now;
            _context.BrewingWortCoolingPE.Add(wortCoolingPE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWortCoolingPE", new { id = wortCoolingPE.Id }, wortCoolingPE);
        }

        // DELETE: api/WortCoolingPE/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WortCoolingPE>> DeleteWortCoolingPE(int id)
        {
            var wortCoolingPE = await _context.BrewingWortCoolingPE.FindAsync(id);
            if (wortCoolingPE == null)
            {
                return NotFound();
            }

            _context.BrewingWortCoolingPE.Remove(wortCoolingPE);
            await _context.SaveChangesAsync();

            return wortCoolingPE;
        }

        private bool WortCoolingPEExists(int id)
        {
            return _context.BrewingWortCoolingPE.Any(e => e.Id == id);
        }
    }
}
