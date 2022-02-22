using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class SafeWorkMethodsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SafeWorkMethodsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SafeWorkMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SafeWorkMethod>>> GetSafeWorkMethod()
        {
            return await _context.SafeWorkMethod.ToListAsync();
        }

        // GET: api/SafeWorkMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SafeWorkMethod>> GetSafeWorkMethod(int id)
        {
            var safeWorkMethod = await _context.SafeWorkMethod.FindAsync(id);

            if (safeWorkMethod == null)
            {
                return NotFound();
            }

            return safeWorkMethod;
        }

        // PUT: api/SafeWorkMethods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSafeWorkMethod(int id, SafeWorkMethod safeWorkMethod)
        {
            if (id != safeWorkMethod.Id)
            {
                return BadRequest();
            }
     
            safeWorkMethod.DateModified = DateTime.Now;
            _context.Entry(safeWorkMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SafeWorkMethodExists(id))
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

        // POST: api/SafeWorkMethods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SafeWorkMethod>> PostSafeWorkMethod(SafeWorkMethod safeWorkMethod)
        {
            safeWorkMethod.DateCreated = DateTime.Now;
            safeWorkMethod.DateModified = DateTime.Now;
            _context.SafeWorkMethod.Add(safeWorkMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSafeWorkMethod", new { id = safeWorkMethod.Id }, safeWorkMethod);
        }

        // DELETE: api/SafeWorkMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SafeWorkMethod>> DeleteSafeWorkMethod(int id)
        {
            var safeWorkMethod = await _context.SafeWorkMethod.FindAsync(id);
            if (safeWorkMethod == null)
            {
                return NotFound();
            }

            _context.SafeWorkMethod.Remove(safeWorkMethod);
            await _context.SaveChangesAsync();

            return safeWorkMethod;
        }

        private bool SafeWorkMethodExists(int id)
        {
            return _context.SafeWorkMethod.Any(e => e.Id == id);
        }
    }
}
