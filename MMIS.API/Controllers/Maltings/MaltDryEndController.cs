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



    public class DryEndMaltController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public DryEndMaltController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/DryEndMalt
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DryEndMalt>>> GetMaltingsDryEndMalt()
        //{
        //    return await _context.MaltingsDryEndMalt.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DryEndMalt>>> GetMaltingsDryEndMalt(string Plant)
        {
            return await _context.MaltingsDryEndMalt.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/DryEndMalt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DryEndMalt>> GetDryEndMalt(int id)
        {
            var obj = await _context.MaltingsDryEndMalt.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/DryEndMalt/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDryEndMalt(int id, DryEndMalt obj)
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
                if (!DryEndMaltExists(id))
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

        // POST: api/DryEndMalt
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DryEndMalt>> PostDryEndMalt(DryEndMalt obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsDryEndMalt.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDryEndMalt", new { id = obj.Id }, obj);
        }

        // DELETE: api/DryEndMalt/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DryEndMalt>> DeleteDryEndMalt(int id)
        {
            var obj = await _context.MaltingsDryEndMalt.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsDryEndMalt.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool DryEndMaltExists(int id)
        {
            return _context.MaltingsDryEndMalt.Any(e => e.Id == id);
        }
    }
}
