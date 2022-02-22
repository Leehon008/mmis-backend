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

    public class InductionInventoryContractorsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public InductionInventoryContractorsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/InductionInventoryContractors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InductionInventoryContractors>>> GetInductionInventoryContractors()
        {
            return await _context.InductionInventoryContractors.ToListAsync();
        }

        // GET: api/InductionInventoryContractors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InductionInventoryContractors>> GetInductionInventoryContractors(int id)
        {
            var inductionInventoryContractors = await _context.InductionInventoryContractors.FindAsync(id);

            if (inductionInventoryContractors == null)
            {
                return NotFound();
            }

            return inductionInventoryContractors;
        }

        // PUT: api/InductionInventoryContractors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInductionInventoryContractors(int id, InductionInventoryContractors inductionInventoryContractors)
        {
            if (id != inductionInventoryContractors.Id)
            {
                return BadRequest();
            }
         //   inductionInventoryContractors.DateCreated = DateTime.Now;
            inductionInventoryContractors.DateModified = DateTime.Now;
            _context.Entry(inductionInventoryContractors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InductionInventoryContractorsExists(id))
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

        // POST: api/InductionInventoryContractors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InductionInventoryContractors>> PostInductionInventoryContractors(InductionInventoryContractors inductionInventoryContractors)
        {
            inductionInventoryContractors.DateCreated = DateTime.Now;
            inductionInventoryContractors.DateModified = DateTime.Now;
            _context.InductionInventoryContractors.Add(inductionInventoryContractors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInductionInventoryContractors", new { id = inductionInventoryContractors.Id }, inductionInventoryContractors);
        }

        // DELETE: api/InductionInventoryContractors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InductionInventoryContractors>> DeleteInductionInventoryContractors(int id)
        {
            var inductionInventoryContractors = await _context.InductionInventoryContractors.FindAsync(id);
            if (inductionInventoryContractors == null)
            {
                return NotFound();
            }

            _context.InductionInventoryContractors.Remove(inductionInventoryContractors);
            await _context.SaveChangesAsync();

            return inductionInventoryContractors;
        }

        private bool InductionInventoryContractorsExists(int id)
        {
            return _context.InductionInventoryContractors.Any(e => e.Id == id);
        }
    }
}
