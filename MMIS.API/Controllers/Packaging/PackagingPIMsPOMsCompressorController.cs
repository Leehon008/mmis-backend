using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class PackagingPIMsPOMsCompressorController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMsCompressorController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMsCompressors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMsCompressor>>> GetPIMsPOMsCompressor()
        {
            return await _context.PIMsPOMsCompressor.ToListAsync();
        }

        // GET: api/PIMsPOMsCompressors/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMsCompressor>>> GetPIMsPOMsCompressor(string ShiftNo)
        {
            var PIMsPOMsCompressor = await _context.PIMsPOMsCompressor.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMsCompressor == null)
            {
                return NotFound();
            }

            return PIMsPOMsCompressor;
        }

        // GET: api/PIMsPOMsCompressors/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMsCompressor>> GetPIMsPOMsCompressor(int id)
        {
            var PIMsPOMsCompressor = await _context.PIMsPOMsCompressor.FindAsync(id);

            if (PIMsPOMsCompressor == null)
            {
                return NotFound();
            }

            return PIMsPOMsCompressor;
        }

        // PUT: api/PIMsPOMsCompressors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMsCompressor(int id, PIMsPOMsCompressor PIMsPOMsCompressor)
        {
            if (id != PIMsPOMsCompressor.Id)
            {
                return BadRequest();
            }
            //PIMsPOMsCompressor. = DateTime.Now;

            _context.Entry(PIMsPOMsCompressor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMsCompressorExists(id))
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

        // POST: api/PIMsPOMsCompressors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMsCompressor>> PostPIMsPOMsCompressor(List<PIMsPOMsCompressor> PIMsPOMsCompressor)
        {
            foreach (var PIMsPOMsCompressorData in PIMsPOMsCompressor)
            {
                _context.PIMsPOMsCompressor.Add(PIMsPOMsCompressorData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMsCompressor", new { PIMsPOMsCompressor });
 
        }

        // DELETE: api/PIMsPOMsCompressors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMsCompressor>> DeletePIMsPOMsCompressor(int id)
        {
            var PIMsPOMsCompressor = await _context.PIMsPOMsCompressor.FindAsync(id);
            if (PIMsPOMsCompressor == null)
            {
                return NotFound();
            }

            _context.PIMsPOMsCompressor.Remove(PIMsPOMsCompressor);
            await _context.SaveChangesAsync();

            return PIMsPOMsCompressor;
        }

        private bool PIMsPOMsCompressorExists(int id)
        {
            return _context.PIMsPOMsCompressor.Any(e => e.Id == id);
        }
    }
}
