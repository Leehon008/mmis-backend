using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Maltings.Entities;

namespace MMIS.API.Controllers.Malting
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class MaltingProcessesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaltingProcessesController(MMISDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltProcesses>>> GetMaltingsMaltProcesses(string Plant)
        {
            return await _context.MaltingsMaltProcesses.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/MaltingProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltProcesses>> GetMaltProcesses(int id)
        {
            var inProcessChecks = await _context.MaltingsMaltProcesses.FindAsync(id);

            if (inProcessChecks == null)
            {
                return NotFound();
            }

            return inProcessChecks;
        }

        // PUT: api/MaltingProcesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltProcesses(int id, MaltProcesses inProcessChecks)
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
                if (!MaltProcessesExists(id))
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

        // POST: api/MaltingProcesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltProcesses>> PostMaltProcesses(MaltProcesses inProcessChecks)
        {
            inProcessChecks.Created = DateTime.Now;
            inProcessChecks.Modified = DateTime.Now;
            _context.MaltingsMaltProcesses.Add(inProcessChecks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltProcesses", new { id = inProcessChecks.Id }, inProcessChecks);
        }

        // DELETE: api/MaltingProcesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltProcesses>> DeleteMaltProcesses(int id)
        {
            var inProcessChecks = await _context.MaltingsMaltProcesses.FindAsync(id);
            if (inProcessChecks == null)
            {
                return NotFound();
            }

            _context.MaltingsMaltProcesses.Remove(inProcessChecks);
            await _context.SaveChangesAsync();

            return inProcessChecks;
        }

        private bool MaltProcessesExists(int id)
        {
            return _context.MaltingsMaltProcesses.Any(e => e.Id == id);
        }
    }
}
