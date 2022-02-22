using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class SustainableDevelopmentController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SustainableDevelopmentController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SustainableDevelopment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SustainableDevelopment>>> GetSustainableDevelopment()
        {
            return await _context.SustainableDevelopment.ToListAsync();
        }

        // GET: api/SustainableDevelopment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SustainableDevelopment>> GetSustainableDevelopment(int id)
        {
            var sustainableDevelopment = await _context.SustainableDevelopment.FindAsync(id);

            if (sustainableDevelopment == null)
            {
                return NotFound();
            }

            return sustainableDevelopment;
        }

        // PUT: api/SustainableDevelopment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSustainableDevelopment(int id, SustainableDevelopment sustainableDevelopment)
        {
            if (id != sustainableDevelopment.Id)
            {
                return BadRequest();
            }
      //      sustainableDevelopment.DateCreated = DateTime.Now;
            sustainableDevelopment.DateModified = DateTime.Now;
            _context.Entry(sustainableDevelopment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SustainableDevelopmentExists(id))
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

        // POST: api/SustainableDevelopment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SustainableDevelopment>> PostSustainableDevelopment(SustainableDevelopment sustainableDevelopment)
        {
            sustainableDevelopment.DateCreated = DateTime.Now;
            sustainableDevelopment.DateModified = DateTime.Now;
            _context.SustainableDevelopment.Add(sustainableDevelopment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSustainableDevelopment", new { id = sustainableDevelopment.Id }, sustainableDevelopment);
        }

        // DELETE: api/SustainableDevelopment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SustainableDevelopment>> DeleteSustainableDevelopment(int id)
        {
            var sustainableDevelopment = await _context.SustainableDevelopment.FindAsync(id);
            if (sustainableDevelopment == null)
            {
                return NotFound();
            }

            _context.SustainableDevelopment.Remove(sustainableDevelopment);
            await _context.SaveChangesAsync();

            return sustainableDevelopment;
        }

        private bool SustainableDevelopmentExists(int id)
        {
            return _context.SustainableDevelopment.Any(e => e.Id == id);
        }
    }
}
