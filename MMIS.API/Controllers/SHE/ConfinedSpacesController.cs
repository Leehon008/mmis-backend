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

    public class ConfinedSpacesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ConfinedSpacesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/ConfinedSpaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfinedSpaces>>> GetConfinedSpaces()
        {
            return await _context.ConfinedSpaces.ToListAsync();
        }

        // GET: api/ConfinedSpaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfinedSpaces>> GetConfinedSpaces(int id)
        {
            var confinedSpaces = await _context.ConfinedSpaces.FindAsync(id);

            if (confinedSpaces == null)
            {
                return NotFound();
            }

            return confinedSpaces;
        }

        // PUT: api/ConfinedSpaces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfinedSpaces(int id, ConfinedSpaces confinedSpaces)
        {
            if (id != confinedSpaces.Id)
            {
                return BadRequest();
            }
            confinedSpaces.DateModified = DateTime.Now;
           
            _context.Entry(confinedSpaces).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfinedSpacesExists(id))
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

        // POST: api/ConfinedSpaces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConfinedSpaces>> PostConfinedSpaces(ConfinedSpaces confinedSpaces)
        {
            confinedSpaces.DateModified = DateTime.Now;
            confinedSpaces.DateCreated = DateTime.Now;
            _context.ConfinedSpaces.Add(confinedSpaces);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfinedSpaces", new { id = confinedSpaces.Id }, confinedSpaces);
        }

        // DELETE: api/ConfinedSpaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfinedSpaces>> DeleteConfinedSpaces(int id)
        {
            var confinedSpaces = await _context.ConfinedSpaces.FindAsync(id);
            if (confinedSpaces == null)
            {
                return NotFound();
            }

            _context.ConfinedSpaces.Remove(confinedSpaces);
            await _context.SaveChangesAsync();

            return confinedSpaces;
        }

        private bool ConfinedSpacesExists(int id)
        {
            return _context.ConfinedSpaces.Any(e => e.Id == id);
        }
    }
}
