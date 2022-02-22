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



    public class GerminationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public GerminationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Germination
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Germination>>> GetMaltingsGermination()
        //{
        //    return await _context.MaltingsGermination.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Germination>>> GetMaltingsGermination(string Plant)
        {
            return await _context.MaltingsGermination.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Germination/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Germination>> GetGermination(int id)
        {
            var obj = await _context.MaltingsGermination.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Germination/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGermination(int id, Germination obj)
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
                if (!GerminationExists(id))
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

        // POST: api/Germination
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Germination>> PostGermination(Germination obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsGermination.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGermination", new { id = obj.Id }, obj);
        }

        // DELETE: api/Germination/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Germination>> DeleteGermination(int id)
        {
            var obj = await _context.MaltingsGermination.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsGermination.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool GerminationExists(int id)
        {
            return _context.MaltingsGermination.Any(e => e.Id == id);
        }
    }
}
