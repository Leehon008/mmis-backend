using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;
using Microsoft.AspNetCore.Authorization;
namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class PermitsAndLicensesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PermitsAndLicensesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PermitsAndLicenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermitsAndLicenses>>> GetPermitsAndLicenses()
        {
            return await _context.PermitsAndLicenses.ToListAsync();
        }

        // GET: api/PermitsAndLicenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermitsAndLicenses>> GetPermitsAndLicenses(int id)
        {
            var permitsAndLicenses = await _context.PermitsAndLicenses.FindAsync(id);

            if (permitsAndLicenses == null)
            {
                return NotFound();
            }

            return permitsAndLicenses;
        }

        // PUT: api/PermitsAndLicenses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermitsAndLicenses(int id, PermitsAndLicenses permitsAndLicenses)
        {
            if (id != permitsAndLicenses.Id)
            {
                return BadRequest();
            }

        
            permitsAndLicenses.DateModified = DateTime.Now;

            _context.Entry(permitsAndLicenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermitsAndLicensesExists(id))
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

        // POST: api/PermitsAndLicenses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PermitsAndLicenses>> PostPermitsAndLicenses(PermitsAndLicenses permitsAndLicenses)
        {
            permitsAndLicenses.DateCreated = DateTime.Now;
            permitsAndLicenses.DateModified = DateTime.Now;
            _context.PermitsAndLicenses.Add(permitsAndLicenses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermitsAndLicenses", new { id = permitsAndLicenses.Id }, permitsAndLicenses);
        }

        // DELETE: api/PermitsAndLicenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PermitsAndLicenses>> DeletePermitsAndLicenses(int id)
        {
            var permitsAndLicenses = await _context.PermitsAndLicenses.FindAsync(id);
            if (permitsAndLicenses == null)
            {
                return NotFound();
            }

            _context.PermitsAndLicenses.Remove(permitsAndLicenses);
            await _context.SaveChangesAsync();

            return permitsAndLicenses;
        }

        private bool PermitsAndLicensesExists(int id)
        {
            return _context.PermitsAndLicenses.Any(e => e.Id == id);
        }
    }
}
