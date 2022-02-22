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

    public class WasteTrackingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public WasteTrackingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/WasteTracking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WasteTracking>>> GetWasteTracking()
        {
            return await _context.WasteTracking.ToListAsync();
        }

        // GET: api/WasteTracking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WasteTracking>> GetWasteTracking(int id)
        {
            var wasteTracking = await _context.WasteTracking.FindAsync(id);

            if (wasteTracking == null)
            {
                return NotFound();
            }

            return wasteTracking;
        }

        // PUT: api/WasteTracking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWasteTracking(int id, WasteTracking wasteTracking)
        {
            if (id != wasteTracking.Id)
            {
                return BadRequest();
            }
            wasteTracking.DateModified = DateTime.Now;
         
            _context.Entry(wasteTracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteTrackingExists(id))
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

        // POST: api/WasteTracking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WasteTracking>> PostWasteTracking(WasteTracking wasteTracking)
        {
            wasteTracking.DateModified = DateTime.Now;
            wasteTracking.DateCreated = DateTime.Now;
            _context.WasteTracking.Add(wasteTracking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWasteTracking", new { id = wasteTracking.Id }, wasteTracking);
        }

        // DELETE: api/WasteTracking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WasteTracking>> DeleteWasteTracking(int id)
        {
            var wasteTracking = await _context.WasteTracking.FindAsync(id);
            if (wasteTracking == null)
            {
                return NotFound();
            }

            _context.WasteTracking.Remove(wasteTracking);
            await _context.SaveChangesAsync();

            return wasteTracking;
        }

        private bool WasteTrackingExists(int id)
        {
            return _context.WasteTracking.Any(e => e.Id == id);
        }
    }
}
