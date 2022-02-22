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

    public class ChemicalCompatibilityController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ChemicalCompatibilityController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/ChemicalCompatibility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChemicalCompatibility>>> GetChemicalCompatibility()
        {
            return await _context.ChemicalCompatibility.ToListAsync();
        }

        // GET: api/ChemicalCompatibility/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChemicalCompatibility>> GetChemicalCompatibility(int id)
        {
            var chemicalCompatibility = await _context.ChemicalCompatibility.FindAsync(id);

            if (chemicalCompatibility == null)
            {
                return NotFound();
            }

            return chemicalCompatibility;
        }

        // PUT: api/ChemicalCompatibility/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChemicalCompatibility(int id, ChemicalCompatibility chemicalCompatibility)
        {
            if (id != chemicalCompatibility.Id)
            {
                return BadRequest();
            }
            chemicalCompatibility.DateModified = DateTime.Now;
            
            _context.Entry(chemicalCompatibility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChemicalCompatibilityExists(id))
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

        // POST: api/ChemicalCompatibility
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChemicalCompatibility>> PostChemicalCompatibility(ChemicalCompatibility chemicalCompatibility)
        {
            chemicalCompatibility.DateModified = DateTime.Now;
            chemicalCompatibility.DateCreated = DateTime.Now;
            _context.ChemicalCompatibility.Add(chemicalCompatibility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChemicalCompatibility", new { id = chemicalCompatibility.Id }, chemicalCompatibility);
        }

        // DELETE: api/ChemicalCompatibility/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChemicalCompatibility>> DeleteChemicalCompatibility(int id)
        {
            var chemicalCompatibility = await _context.ChemicalCompatibility.FindAsync(id);
            if (chemicalCompatibility == null)
            {
                return NotFound();
            }

            _context.ChemicalCompatibility.Remove(chemicalCompatibility);
            await _context.SaveChangesAsync();

            return chemicalCompatibility;
        }

        private bool ChemicalCompatibilityExists(int id)
        {
            return _context.ChemicalCompatibility.Any(e => e.Id == id);
        }
    }
}
