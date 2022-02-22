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


    public class BrewingProcessesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingProcessesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingProcesses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<InProcessChecks>>> GetBrewingIPC()
        //{
        //    return await _context.BrewingIPC.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<InProcessChecks>>> GetBrewingIPC(string Plant)
        {
            return await _context.BrewingIPC.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InProcessChecks>> GetInProcessChecks(int id)
        {
            var inProcessChecks = await _context.BrewingIPC.FindAsync(id);

            if (inProcessChecks == null)
            {
                return NotFound();
            }

            return inProcessChecks;
        }

        // PUT: api/BrewingProcesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInProcessChecks(int id, InProcessChecks inProcessChecks)
        {
            if (id != inProcessChecks.Id)
            {
                return BadRequest();
            }
            inProcessChecks.Modified = DateTime.Now;
            _context.Entry(inProcessChecks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InProcessChecksExists(id))
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

        // POST: api/BrewingProcesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InProcessChecks>> PostInProcessChecks(InProcessChecks inProcessChecks)
        {
            inProcessChecks.Created = DateTime.Now;
            inProcessChecks.Modified = DateTime.Now;
            _context.BrewingIPC.Add(inProcessChecks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInProcessChecks", new { id = inProcessChecks.Id }, inProcessChecks);
        }

        // DELETE: api/BrewingProcesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InProcessChecks>> DeleteInProcessChecks(int id)
        {
            var inProcessChecks = await _context.BrewingIPC.FindAsync(id);
            if (inProcessChecks == null)
            {
                return NotFound();
            }

            _context.BrewingIPC.Remove(inProcessChecks);
            await _context.SaveChangesAsync();

            return inProcessChecks;
        }

        private bool InProcessChecksExists(int id)
        {
            return _context.BrewingIPC.Any(e => e.Id == id);
        }
    }
}
