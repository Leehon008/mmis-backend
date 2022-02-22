using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using Microsoft.AspNetCore.Authorization;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class HzSubstancesInventoryController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public HzSubstancesInventoryController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/HzSubstancesInventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HzSubstancesInventory>>> GetHzSubstancesInventory()
        {
            return await _context.HzSubstancesInventory.ToListAsync();
        }

        // GET: api/HzSubstancesInventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HzSubstancesInventory>> GetHzSubstancesInventory(int id)
        {
            var hzSubstancesInventory = await _context.HzSubstancesInventory.FindAsync(id);

            if (hzSubstancesInventory == null)
            {
                return NotFound();
            }

            return hzSubstancesInventory;
        }

        // PUT: api/HzSubstancesInventory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHzSubstancesInventory(int id, HzSubstancesInventory hzSubstancesInventory)
        {
            if (id != hzSubstancesInventory.Id)
            {
                return BadRequest();
            }
            hzSubstancesInventory.DateModified = DateTime.Now;
   
            _context.Entry(hzSubstancesInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HzSubstancesInventoryExists(id))
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

        // POST: api/HzSubstancesInventory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HzSubstancesInventory>> PostHzSubstancesInventory(HzSubstancesInventory hzSubstancesInventory)
        {
            hzSubstancesInventory.DateModified = DateTime.Now;
            hzSubstancesInventory.DateCreated = DateTime.Now;
            _context.HzSubstancesInventory.Add(hzSubstancesInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHzSubstancesInventory", new { id = hzSubstancesInventory.Id }, hzSubstancesInventory);
        }

        // DELETE: api/HzSubstancesInventory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HzSubstancesInventory>> DeleteHzSubstancesInventory(int id)
        {
            var hzSubstancesInventory = await _context.HzSubstancesInventory.FindAsync(id);
            if (hzSubstancesInventory == null)
            {
                return NotFound();
            }

            _context.HzSubstancesInventory.Remove(hzSubstancesInventory);
            await _context.SaveChangesAsync();

            return hzSubstancesInventory;
        }

        private bool HzSubstancesInventoryExists(int id)
        {
            return _context.HzSubstancesInventory.Any(e => e.Id == id);
        }
    }
}
