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

    public class InductionInventoryController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public InductionInventoryController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/InductionInventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InductionInventory>>> GetInductionInventory()
        {
            return await _context.InductionInventory.ToListAsync();
        }

        // GET: api/InductionInventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InductionInventory>> GetInductionInventory(int id)
        {
            var inductionInventory = await _context.InductionInventory.FindAsync(id);

            if (inductionInventory == null)
            {
                return NotFound();
            }

            return inductionInventory;
        }

        // PUT: api/InductionInventory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInductionInventory(int id, InductionInventory inductionInventory)
        {
            if (id != inductionInventory.Id)
            {
                return BadRequest();
            }
            //inductionInventory.DateCreated = DateTime.Now;
            inductionInventory.DateModified = DateTime.Now;

            _context.Entry(inductionInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InductionInventoryExists(id))
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

        // POST: api/InductionInventory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InductionInventory>> PostInductionInventory(InductionInventory inductionInventory)
        {
            inductionInventory.DateCreated = DateTime.Now;
            inductionInventory.DateModified = DateTime.Now;
            _context.InductionInventory.Add(inductionInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInductionInventory", new { id = inductionInventory.Id }, inductionInventory);
        }

        // DELETE: api/InductionInventory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InductionInventory>> DeleteInductionInventory(int id)
        {
            var inductionInventory = await _context.InductionInventory.FindAsync(id);
            if (inductionInventory == null)
            {
                return NotFound();
            }

            _context.InductionInventory.Remove(inductionInventory);
            await _context.SaveChangesAsync();

            return inductionInventory;
        }

        private bool InductionInventoryExists(int id)
        {
            return _context.InductionInventory.Any(e => e.Id == id);
        }
    }
}
