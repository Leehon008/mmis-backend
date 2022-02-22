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

    public class SHETargetsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SHETargetsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SHETargets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SHETargetsHeader>>> GetSHETargetsHeader()
        {
            return await _context.SHETargetsHeader.ToListAsync();
        }

        // GET: api/SHETargets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SHETargetsHeader>> GetSHETargetsHeader(int id)
        {
            var sHETargetsHeader = await _context.SHETargetsHeader.FindAsync(id);

            if (sHETargetsHeader == null)
            {
                return NotFound();
            }

            return sHETargetsHeader;
        }

        // PUT: api/SHETargets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSHETargetsHeader(int id, SHETargetsHeader sHETargetsHeader)
        {
            if (id != sHETargetsHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(sHETargetsHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SHETargetsHeaderExists(id))
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

        // POST: api/SHETargets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SHETargetsHeader>> PostSHETargetsHeader(SHETargetsHeader sHETargetsHeader)
        {
            _context.SHETargetsHeader.Add(sHETargetsHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSHETargetsHeader", new { id = sHETargetsHeader.Id }, sHETargetsHeader);
        }

        // DELETE: api/SHETargets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SHETargetsHeader>> DeleteSHETargetsHeader(int id)
        {
            var sHETargetsHeader = await _context.SHETargetsHeader.FindAsync(id);
            if (sHETargetsHeader == null)
            {
                return NotFound();
            }

            _context.SHETargetsHeader.Remove(sHETargetsHeader);
            await _context.SaveChangesAsync();

            return sHETargetsHeader;
        }

        private bool SHETargetsHeaderExists(int id)
        {
            return _context.SHETargetsHeader.Any(e => e.Id == id);
        }
    }
}
