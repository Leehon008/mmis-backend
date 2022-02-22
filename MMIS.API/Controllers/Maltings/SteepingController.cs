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



    public class SteepingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SteepingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Steeping
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Steeping>>> GetMaltingsSteeping()
        //{
        //    return await _context.MaltingsSteeping.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Steeping>>> GetMaltingsSteeping(string Plant)
        {
            return await _context.MaltingsSteeping.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Steeping/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Steeping>> GetSteeping(int id)
        {
            var obj = await _context.MaltingsSteeping.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Steeping/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSteeping(int id, Steeping obj)
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
                if (!SteepingExists(id))
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

        // POST: api/Steeping
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Steeping>> PostSteeping(Steeping obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsSteeping.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSteeping", new { id = obj.Id }, obj);
        }

        // DELETE: api/Steeping/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Steeping>> DeleteSteeping(int id)
        {
            var obj = await _context.MaltingsSteeping.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsSteeping.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool SteepingExists(int id)
        {
            return _context.MaltingsSteeping.Any(e => e.Id == id);
        }
    }
}
