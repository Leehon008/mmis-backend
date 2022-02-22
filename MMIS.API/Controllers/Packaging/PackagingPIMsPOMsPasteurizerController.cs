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

    public class PackagingPIMsPOMsPasteurizerController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingPIMsPOMsPasteurizerController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIMsPOMsPasteurizers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIMsPOMsPasteurizer>>> GetPIMsPOMsPasteurizer()
        {
            return await _context.PIMsPOMsPasteurizer.ToListAsync();
        }

        // GET: api/PIMsPOMsPasteurizers/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<PIMsPOMsPasteurizer>>> GetPIMsPOMsPasteurizer(string ShiftNo)
        {
            var PIMsPOMsPasteurizer = await _context.PIMsPOMsPasteurizer.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (PIMsPOMsPasteurizer == null)
            {
                return NotFound();
            }

            return PIMsPOMsPasteurizer;
        }

        // GET: api/PIMsPOMsPasteurizers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PIMsPOMsPasteurizer>> GetPIMsPOMsPasteurizer(int id)
        {
            var PIMsPOMsPasteurizer = await _context.PIMsPOMsPasteurizer.FindAsync(id);

            if (PIMsPOMsPasteurizer == null)
            {
                return NotFound();
            }

            return PIMsPOMsPasteurizer;
        }

        // PUT: api/PIMsPOMsPasteurizers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIMsPOMsPasteurizer(int id, PIMsPOMsPasteurizer PIMsPOMsPasteurizer)
        {
            if (id != PIMsPOMsPasteurizer.Id)
            {
                return BadRequest();
            }
            //PIMsPOMsPasteurizer. = DateTime.Now;

            _context.Entry(PIMsPOMsPasteurizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIMsPOMsPasteurizerExists(id))
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

        // POST: api/PIMsPOMsPasteurizers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PIMsPOMsPasteurizer>> PostPIMsPOMsPasteurizer(List<PIMsPOMsPasteurizer> PIMsPOMsPasteurizer)
        {
            foreach (var PIMsPOMsPasteurizerData in PIMsPOMsPasteurizer)
            {
                _context.PIMsPOMsPasteurizer.Add(PIMsPOMsPasteurizerData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPIMsPOMsPasteurizer", new { PIMsPOMsPasteurizer });
 
        }

        // DELETE: api/PIMsPOMsPasteurizers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PIMsPOMsPasteurizer>> DeletePIMsPOMsPasteurizer(int id)
        {
            var PIMsPOMsPasteurizer = await _context.PIMsPOMsPasteurizer.FindAsync(id);
            if (PIMsPOMsPasteurizer == null)
            {
                return NotFound();
            }

            _context.PIMsPOMsPasteurizer.Remove(PIMsPOMsPasteurizer);
            await _context.SaveChangesAsync();

            return PIMsPOMsPasteurizer;
        }

        private bool PIMsPOMsPasteurizerExists(int id)
        {
            return _context.PIMsPOMsPasteurizer.Any(e => e.Id == id);
        }
    }
}
