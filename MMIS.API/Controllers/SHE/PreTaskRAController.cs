using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
   // //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class PreTaskRAController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PreTaskRAController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PreTaskRAHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreTaskRAHeader>>> GetPreTaskRAHeader()
        {
            return await _context.PreTaskRAHeader.ToListAsync();
        }

        // GET: api/PreTaskRAHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreTaskRAHeader>> GetPreTaskRAHeader(int id)
        {
            var preTaskRAHeader = await _context.PreTaskRAHeader.FindAsync(id);

            if (preTaskRAHeader == null)
            {
                return NotFound();
            }

            return preTaskRAHeader;
        }

        // PUT: api/PreTaskRAHeaders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreTaskRAHeader(int id, PreTaskRAHeader preTaskRAHeader)
        {
            if (id != preTaskRAHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(preTaskRAHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreTaskRAHeaderExists(id))
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

        // POST: api/PreTaskRAHeaders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreTaskRAHeader>> PostPreTaskRAHeader(PreTaskRAHeader preTaskRAHeader)
        {
            _context.PreTaskRAHeader.Add(preTaskRAHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreTaskRAHeader", new { id = preTaskRAHeader.Id }, preTaskRAHeader);
        }

        // DELETE: api/PreTaskRAHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreTaskRAHeader>> DeletePreTaskRAHeader(int id)
        {
            var preTaskRAHeader = await _context.PreTaskRAHeader.FindAsync(id);
            if (preTaskRAHeader == null)
            {
                return NotFound();
            }

            _context.PreTaskRAHeader.Remove(preTaskRAHeader);
            await _context.SaveChangesAsync();

            return preTaskRAHeader;
        }

        private bool PreTaskRAHeaderExists(int id)
        {
            return _context.PreTaskRAHeader.Any(e => e.Id == id);
        }
    }
}
