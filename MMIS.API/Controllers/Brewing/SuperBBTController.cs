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



    public class SuperBBTController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SuperBBTController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SuperBBT
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SuperBBT>>> GetBrewingSuperBBT()
        //{
        //    return await _context.BrewingSuperBBT.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperBBT>>> GetBrewingSuperBBT(string Plant)
        {
            return await _context.BrewingSuperBBT.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Time).ToListAsync();
        }

        // GET: api/SuperBBT/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperBBT>> GetSuperBBT(int id)
        {
            var bbt = await _context.BrewingSuperBBT.FindAsync(id);

            if (bbt == null)
            {
                return NotFound();
            }

            return bbt;
        }

        // PUT: api/SuperBBT/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperBBT(int id, SuperBBT bbt)
        {
            if (id != bbt.Id)
            {
                return BadRequest();
            }
            bbt.Modified = DateTime.Now;

            _context.Entry(bbt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperBBTExists(id))
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

        // POST: api/SuperBBT
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SuperBBT>> PostSuperBBT(SuperBBT bbt)
        {
            bbt.Modified = DateTime.Now;
            bbt.Modified = DateTime.Now;
            _context.BrewingSuperBBT.Add(bbt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperBBT", new { id = bbt.Id }, bbt);
        }

        // DELETE: api/SuperBBT/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperBBT>> DeleteSuperBBT(int id)
        {
            var bbt = await _context.BrewingSuperBBT.FindAsync(id);
            if (bbt == null)
            {
                return NotFound();
            }

            _context.BrewingSuperBBT.Remove(bbt);
            await _context.SaveChangesAsync();

            return bbt;
        }

        private bool SuperBBTExists(int id)
        {
            return _context.BrewingSuperBBT.Any(e => e.Id == id);
        }
    }
}
