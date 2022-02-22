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

    public class FRAHeadersController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public FRAHeadersController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/FRAHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FRAHeader>>> GetFRAHeader()
        {
            return await _context.FRAHeader.ToListAsync();
        }

        // GET: api/FRAHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FRAHeader>> GetFRAHeader(int id)
        {
            var fRAHeader = await _context.FRAHeader.FindAsync(id);

            if (fRAHeader == null)
            {
                return NotFound();
            }

            return fRAHeader;
        }
      
        // PUT: api/FRAHeaders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFRAHeader(int id, FRAHeader fRAHeader)
        {
            if (id != fRAHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(fRAHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FRAHeaderExists(id))
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

        // POST: api/FRAHeaders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FRAHeader>> PostFRAHeader(FRAHeader fRAHeader)
        {
            _context.FRAHeader.Add(fRAHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFRAHeader", new { id = fRAHeader.Id }, fRAHeader);
        }

        // DELETE: api/FRAHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FRAHeader>> DeleteFRAHeader(int id)
        {
            var fRAHeader = await _context.FRAHeader.FindAsync(id);
            if (fRAHeader == null)
            {
                return NotFound();
            }

            _context.FRAHeader.Remove(fRAHeader);
            await _context.SaveChangesAsync();

            return fRAHeader;
        }

        private bool FRAHeaderExists(int id)
        {
            return _context.FRAHeader.Any(e => e.Id == id);
        }
    }
}
