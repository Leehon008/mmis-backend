using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class LegalOtherRequirementsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public LegalOtherRequirementsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/LegalOtherRequirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalOtherHeader>>> GetLegalOtherHeader()
        {
            return await _context.LegalOtherHeader.ToListAsync();
        }

        // GET: api/LegalOtherRequirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalOtherHeader>> GetLegalOtherHeader(int id)
        {
            var legalOtherHeader = await _context.LegalOtherHeader.FindAsync(id);

            if (legalOtherHeader == null)
            {
                return NotFound();
            }

            return legalOtherHeader;
        }

        // PUT: api/LegalOtherRequirements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalOtherHeader(int id, LegalOtherHeader legalOtherHeader)
        {
            if (id != legalOtherHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(legalOtherHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalOtherHeaderExists(id))
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

        // POST: api/LegalOtherRequirements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LegalOtherHeader>> PostLegalOtherHeader(LegalOtherHeader legalOtherHeader)
        {
            _context.LegalOtherHeader.Add(legalOtherHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegalOtherHeader", new { id = legalOtherHeader.Id }, legalOtherHeader);
        }

        // DELETE: api/LegalOtherRequirements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegalOtherHeader>> DeleteLegalOtherHeader(int id)
        {
            var legalOtherHeader = await _context.LegalOtherHeader.FindAsync(id);
            if (legalOtherHeader == null)
            {
                return NotFound();
            }

            _context.LegalOtherHeader.Remove(legalOtherHeader);
            await _context.SaveChangesAsync();

            return legalOtherHeader;
        }

        private bool LegalOtherHeaderExists(int id)
        {
            return _context.LegalOtherHeader.Any(e => e.Id == id);
        }
    }
}
