using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class RATeamsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public RATeamsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/RATeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RATeams>>> GetHRATeams()
        {
            return await _context.HRATeams.ToListAsync();
        }

        // GET: api/RATeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RATeams>> GetRATeams(int id)
        {
            var rATeams = await _context.HRATeams.FindAsync(id);

            if (rATeams == null)
            {
                return NotFound();
            }

            return rATeams;
        }

        // PUT: api/RATeams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRATeams(int id, RATeams rATeams)
        {
            if (id != rATeams.Id)
            {
                return BadRequest();
            }
            _context.Attach(rATeams);

            var entry = _context.Entry(rATeams);


            if (rATeams.Id == 0)
            {
              
                entry.State = EntityState.Added;
                rATeams.DateCreated = DateTime.Now;
            }
            else
            {
                entry.Property(e => e.DateCreated).IsModified = false;
                entry.State = EntityState.Modified;
            }
            

            rATeams.ModifiedOn = DateTime.Now;
            


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RATeamsExists(id))
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

        // POST: api/RATeams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RATeams>> PostRATeams(RATeams rATeams)
        {
            rATeams.ModifiedOn = DateTime.Now;
            rATeams.CreatedOn = DateTime.Now;
            _context.HRATeams.Add(rATeams);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRATeams", new { id = rATeams.Id }, rATeams);
        }

        // DELETE: api/RATeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RATeams>> DeleteRATeams(int id)
        {
            var rATeams = await _context.HRATeams.FindAsync(id);
            if (rATeams == null)
            {
                return NotFound();
            }

            _context.HRATeams.Remove(rATeams);
            await _context.SaveChangesAsync();

            return rATeams;
        }

        private bool RATeamsExists(int id)
        {
            return _context.HRATeams.Any(e => e.Id == id);
        }
    }
}
