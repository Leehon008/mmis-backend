using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Maltings.Entities;

namespace MMIS.API.Controllers.Maltings
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class MaltingCyclesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaltingCyclesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltingCycles
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaltingCycle>>> GetMaltingCycles()
        //{
        //    return await _context.MaltingsMaltingCycle.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltingCycle>>> GetMaltingCycles(string Plant)
        {
            return await _context.MaltingsMaltingCycle.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/MaltingCycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltingCycle>> GetMaltingCycle(int id)
        {
            var obj = await _context.MaltingsMaltingCycle.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/MaltingCycles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltingCycle(int id, MaltingCycle obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            //_context.Entry(obj).State = EntityState.Modified;
            obj.Modified = DateTime.Now;
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Processes.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MaltingsMaltingCycle.Find(obj.Id)
                        .Processes.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in obj.Stoppages.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MaltingsMaltingCycle.Find(obj.Id)
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
                if (!MaltingCycleExists(id))
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

        // POST: api/MaltingCycles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltingCycle>> PostMaltingCycle(MaltingCycle obj)
        {
            _context.MaltingsMaltingCycle.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltingCycle", new { id = obj.Id }, obj);
        }

        // DELETE: api/MaltingCycles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltingCycle>> DeleteMaltingCycle(int id)
        {
            var obj = await _context.MaltingsMaltingCycle.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            //_context.MaltingsMaltingCycle.Remove(obj);

            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Deleted;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Processes)
            {
                var entityEntry = _context.Entry(_context.MaltingsMaltingCycle.Find(obj.Id)
                    .Processes.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in obj.Stoppages)
            {
                var entityEntry = _context.Entry(_context.MaltingsMaltingCycle.Find(obj.Id)
                    .Stoppages.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();

            return obj;
        }

        private bool MaltingCycleExists(int id)
        {
            return _context.MaltingsMaltingCycle.Any(e => e.Id == id);
        }
    }
}
