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



    public class OverseerInputController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public OverseerInputController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/OverseerInput
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OverseerInput>>> GetMaltingsOverseerInput()
        //{
        //    return await _context.MaltingsOverseerInput.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OverseerInput>>> GetMaltingsOverseerInput(string Plant)
        {
            return await _context.MaltingsOverseerInput.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/OverseerInput/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OverseerInput>> GetOverseerInput(int id)
        {
            var obj = await _context.MaltingsOverseerInput.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/OverseerInput/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOverseerInput(int id, OverseerInput obj)
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
                if (!OverseerInputExists(id))
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

        // POST: api/OverseerInput
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OverseerInput>> PostOverseerInput(OverseerInput obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsOverseerInput.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOverseerInput", new { id = obj.Id }, obj);
        }

        // DELETE: api/OverseerInput/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OverseerInput>> DeleteOverseerInput(int id)
        {
            var obj = await _context.MaltingsOverseerInput.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsOverseerInput.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool OverseerInputExists(int id)
        {
            return _context.MaltingsOverseerInput.Any(e => e.Id == id);
        }
    }
}
