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

    public class SRAHeadersController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SRAHeadersController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SRAHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SRAHeader>>> GetSRAHeader()
        {
            return await _context.SRAHeader.ToListAsync();
        }

        // GET: api/SRAHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SRAHeader>> GetSRAHeader(int id)
        {
            var sRAHeader = await _context.SRAHeader.FindAsync(id);

            if (sRAHeader == null)
            {
                return NotFound();
            }

            return sRAHeader;
        }

        // PUT: api/SRAHeaders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSRAHeader(int id, SRAHeader sRAHeader)
        {
            if (id != sRAHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(sRAHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SRAHeaderExists(id))
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

        // POST: api/SRAHeaders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SRAHeader>> PostSRAHeader(SRAHeader sRAHeader)
        {
            _context.SRAHeader.Add(sRAHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSRAHeader", new { id = sRAHeader.Id }, sRAHeader);
        }

        // DELETE: api/SRAHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SRAHeader>> DeleteSRAHeader(int id)
        {
            var sRAHeader = await _context.SRAHeader.FindAsync(id);
            if (sRAHeader == null)
            {
                return NotFound();
            }

            _context.SRAHeader.Remove(sRAHeader);
            await _context.SaveChangesAsync();

            return sRAHeader;
        }

        private bool SRAHeaderExists(int id)
        {
            return _context.SRAHeader.Any(e => e.Id == id);
        }
    }
}
