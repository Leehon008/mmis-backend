using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class WasteManagementController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public WasteManagementController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/WasteManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WasteManagement>>> GetWasteManagement()
        {
            return await _context.WasteManagement.ToListAsync();
        }

        // GET: api/WasteManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WasteManagement>> GetWasteManagement(int id)
        {
            var wasteManagement = await _context.WasteManagement.FindAsync(id);

            if (wasteManagement == null)
            {
                return NotFound();
            }

            return wasteManagement;
        }

        // PUT: api/WasteManagement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWasteManagement(int id, WasteManagement wasteManagement)
        {
            if (id != wasteManagement.Id)
            {
                return BadRequest();
            }
            wasteManagement.DateCreated = DateTime.Now;
            wasteManagement.DateModified = DateTime.Now;
            _context.Entry(wasteManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteManagementExists(id))
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

        // POST: api/WasteManagement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WasteManagement>> PostWasteManagement(WasteManagement wasteManagement)
        {
            wasteManagement.DateModified = DateTime.Now;
            _context.WasteManagement.Add(wasteManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWasteManagement", new { id = wasteManagement.Id }, wasteManagement);
        }

        // DELETE: api/WasteManagement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WasteManagement>> DeleteWasteManagement(int id)
        {
            var wasteManagement = await _context.WasteManagement.FindAsync(id);
            if (wasteManagement == null)
            {
                return NotFound();
            }

            _context.WasteManagement.Remove(wasteManagement);
            await _context.SaveChangesAsync();

            return wasteManagement;
        }

        private bool WasteManagementExists(int id)
        {
            return _context.WasteManagement.Any(e => e.Id == id);
        }
    }
}
