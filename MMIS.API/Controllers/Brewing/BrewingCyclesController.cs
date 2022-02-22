using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Brewing.Entities;

namespace MMIS.API.Controllers.Brewing
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class BrewingCyclesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingCyclesController(MMISDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrewingCycle>>> GetBrewingCycles(string Plant)
        {
            return await _context.BrewingCycles.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        // GET: api/BrewingCycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrewingCycle>> GetBrewingCycle(int id)
        {
            var brewingCycle = await _context.BrewingCycles.FindAsync(id);

            if (brewingCycle == null)
            {
                return NotFound();
            }

            return brewingCycle;
        }


        // GET: api/BrewingCycles/5
        [HttpGet("GetBrewingCycleByBrewId/{brewId}")]
        public async Task<ActionResult<IEnumerable<BrewingCycle>>> GetBrewingCycleByBrewId(string brewId)
        {
            var brewingCycle = await _context.BrewingCycles.Where(m=>m.BrewId.Equals(brewId)).ToListAsync();

            if (brewingCycle == null)
            {
                return NotFound();
            }

            return brewingCycle;
        }


        // PUT: api/BrewingCycles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewingCycle(int id, BrewingCycle brewingCycle)
        {
            if (id != brewingCycle.Id)
            {
                return BadRequest();
            }

            //_context.Entry(brewingCycle).State = EntityState.Modified;
            brewingCycle.Modified = DateTime.Now;
            _context.Attach(brewingCycle);

            var entry = _context.Entry(brewingCycle);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in brewingCycle.Processes.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.BrewingCycles.Find(brewingCycle.Id)
                        .Processes.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in brewingCycle.Stoppages.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.BrewingCycles.Find(brewingCycle.Id)
                        .Stoppages.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewingCycleExists(id))
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

        // POST: api/BrewingCycles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewingCycle>> PostBrewingCycle(BrewingCycle brewingCycle)
        {
            brewingCycle.Created = DateTime.Now;
            brewingCycle.Modified = DateTime.Now;
            _context.BrewingCycles.Add(brewingCycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewingCycle", new { id = brewingCycle.Id }, brewingCycle);
        }

        // DELETE: api/BrewingCycles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrewingCycle>> DeleteBrewingCycle(int id)
        {
            var brewingCycle = await _context.BrewingCycles.FindAsync(id);
            if (brewingCycle == null)
            {
                return NotFound();
            }

            _context.BrewingCycles.Remove(brewingCycle);
            await _context.SaveChangesAsync();

            return brewingCycle;
        }

        private bool BrewingCycleExists(int id)
        {
            return _context.BrewingCycles.Any(e => e.Id == id);
        }
    }
}
