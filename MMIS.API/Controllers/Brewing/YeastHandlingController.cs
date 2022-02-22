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



    public class YeastHandlingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public YeastHandlingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/YeastHandling
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<YeastHandling>>> GetBrewingYeastHandling()
        //{
        //    return await _context.BrewingYeastHandling.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<YeastHandling>>> GetBrewingYeastHandling(string Plant)
        {
            return await _context.BrewingYeastHandling.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/YeastHandling/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YeastHandling>> GetYeastHandling(int id)
        {
            var yeastHandling = await _context.BrewingYeastHandling.FindAsync(id);

            if (yeastHandling == null)
            {
                return NotFound();
            }

            return yeastHandling;
        }

        // PUT: api/YeastHandling/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYeastHandling(int id, YeastHandling yeastHandling)
        {
            if (id != yeastHandling.Id)
            {
                return BadRequest();
            }

            yeastHandling.Modified = DateTime.Now;
            _context.Entry(yeastHandling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YeastHandlingExists(id))
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

        // POST: api/YeastHandling
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<YeastHandling>> PostYeastHandling(YeastHandling yeastHandling)
        {
            yeastHandling.Created = DateTime.Now;
            yeastHandling.Modified = DateTime.Now;
            _context.BrewingYeastHandling.Add(yeastHandling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYeastHandling", new { id = yeastHandling.Id }, yeastHandling);
        }

        // DELETE: api/YeastHandling/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YeastHandling>> DeleteYeastHandling(int id)
        {
            var yeastHandling = await _context.BrewingYeastHandling.FindAsync(id);
            if (yeastHandling == null)
            {
                return NotFound();
            }

            _context.BrewingYeastHandling.Remove(yeastHandling);
            await _context.SaveChangesAsync();

            return yeastHandling;
        }

        private bool YeastHandlingExists(int id)
        {
            return _context.BrewingYeastHandling.Any(e => e.Id == id);
        }
    }
}
