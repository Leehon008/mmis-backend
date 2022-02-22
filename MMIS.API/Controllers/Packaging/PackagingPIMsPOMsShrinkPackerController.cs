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

    public class PackagingPIMsPOMShrinkPackerController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMShrinkPackerController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMShrinkPackers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMShrinkPacker>>> GetPIMsPOMShrinkPacker()
        {
            return await _context.PIMsPOMShrinkPacker.ToListAsync();
        }

        // GET: api/PIMsPOMShrinkPackers/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMShrinkPacker>>> GetPIMsPOMShrinkPacker(string ShiftNo)
        {
            var PIMsPOMShrinkPacker = await _context.PIMsPOMShrinkPacker.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMShrinkPacker == null)
            {
                return NotFound();
            }

            return PIMsPOMShrinkPacker;
        }

        // GET: api/PIMsPOMShrinkPackers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMShrinkPacker>> GetPIMsPOMShrinkPacker(int id)
        {
            var PIMsPOMShrinkPacker = await _context.PIMsPOMShrinkPacker.FindAsync(id);

            if (PIMsPOMShrinkPacker == null)
            {
                return NotFound();
            }

            return PIMsPOMShrinkPacker;
        }

        // PUT: api/PIMsPOMShrinkPackers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMShrinkPacker(int id, PIMsPOMShrinkPacker PIMsPOMShrinkPacker)
        {
            if (id != PIMsPOMShrinkPacker.Id)
            {
                return BadRequest();
            }
            //PIMsPOMShrinkPacker. = DateTime.Now;

            _context.Entry(PIMsPOMShrinkPacker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMShrinkPackerExists(id))
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

        // POST: api/PIMsPOMShrinkPackers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMShrinkPacker>> PostPIMsPOMShrinkPacker(List<PIMsPOMShrinkPacker> PIMsPOMShrinkPacker)
        {
            foreach (var PIMsPOMShrinkPackerData in PIMsPOMShrinkPacker)
            {
                _context.PIMsPOMShrinkPacker.Add(PIMsPOMShrinkPackerData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMShrinkPacker", new { PIMsPOMShrinkPacker });
 
        }

        // DELETE: api/PIMsPOMShrinkPackers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMShrinkPacker>> DeletePIMsPOMShrinkPacker(int id)
        {
            var PIMsPOMShrinkPacker = await _context.PIMsPOMShrinkPacker.FindAsync(id);
            if (PIMsPOMShrinkPacker == null)
            {
                return NotFound();
            }

            _context.PIMsPOMShrinkPacker.Remove(PIMsPOMShrinkPacker);
            await _context.SaveChangesAsync();

            return PIMsPOMShrinkPacker;
        }

        private bool PIMsPOMShrinkPackerExists(int id)
        {
            return _context.PIMsPOMShrinkPacker.Any(e => e.Id == id);
        }
    }
}
