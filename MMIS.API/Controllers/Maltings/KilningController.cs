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



    public class KilningController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public KilningController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Kilning
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Kilning>>> GetMaltingsKilning()
        //{
        //    return await _context.MaltingsKilning.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kilning>>> GetMaltingsKilning(string Plant)
        {
            return await _context.MaltingsKilning.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Kilning/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kilning>> GetKilning(int id)
        {
            var obj = await _context.MaltingsKilning.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Kilning/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKilning(int id, Kilning obj)
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
                if (!KilningExists(id))
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

        // POST: api/Kilning
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kilning>> PostKilning(Kilning obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsKilning.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKilning", new { id = obj.Id }, obj);
        }

        // DELETE: api/Kilning/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kilning>> DeleteKilning(int id)
        {
            var obj = await _context.MaltingsKilning.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsKilning.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool KilningExists(int id)
        {
            return _context.MaltingsKilning.Any(e => e.Id == id);
        }
    }
}
