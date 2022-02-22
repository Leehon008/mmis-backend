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



    public class SorghumGrainController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SorghumGrainController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SorghumGrain
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SorghumGrain>>> GetMaltingsSorghumGrain()
        //{
        //    return await _context.MaltingsSorghumGrain.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SorghumGrain>>> GetMaltingsSorghumGrain(string Plant)
        {
            return await _context.MaltingsSorghumGrain.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/SorghumGrain/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SorghumGrain>> GetSorghumGrain(int id)
        {
            var obj = await _context.MaltingsSorghumGrain.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/SorghumGrain/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSorghumGrain(int id, SorghumGrain obj)
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
                if (!SorghumGrainExists(id))
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

        // POST: api/SorghumGrain
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SorghumGrain>> PostSorghumGrain(SorghumGrain obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsSorghumGrain.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSorghumGrain", new { id = obj.Id }, obj);
        }

        // DELETE: api/SorghumGrain/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SorghumGrain>> DeleteSorghumGrain(int id)
        {
            var obj = await _context.MaltingsSorghumGrain.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsSorghumGrain.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool SorghumGrainExists(int id)
        {
            return _context.MaltingsSorghumGrain.Any(e => e.Id == id);
        }
    }
}
