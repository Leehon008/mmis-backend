using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Maltings.Entities;

namespace MMIS.API.Controllers.Maltings
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]



    public class WetEndMaltController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public WetEndMaltController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/WetEndMalt
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WetEndMalt>>> GetMaltingsWetEndMalt()
        //{
        //    return await _context.MaltingsWetEndMalt.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WetEndMalt>>> GetMaltingsWetEndMalt(string Plant)
        {
            return await _context.MaltingsWetEndMalt.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/WetEndMalt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WetEndMalt>> GetWetEndMalt(int id)
        {
            var obj = await _context.MaltingsWetEndMalt.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/WetEndMalt/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWetEndMalt(int id, WetEndMalt obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }
            obj.Modified = DateTime.Now;

            _context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WetEndMaltExists(id))
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

        // POST: api/WetEndMalt
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WetEndMalt>> PostWetEndMalt(WetEndMalt obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsWetEndMalt.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWetEndMalt", new { id = obj.Id }, obj);
        }

        // DELETE: api/WetEndMalt/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WetEndMalt>> DeleteWetEndMalt(int id)
        {
            var obj = await _context.MaltingsWetEndMalt.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsWetEndMalt.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool WetEndMaltExists(int id)
        {
            return _context.MaltingsWetEndMalt.Any(e => e.Id == id);
        }
    }
}
