using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class SwmsTeamsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SwmsTeamsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SwmsTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwmsTeam>>> GetSwmsTeam()
        {
            return await _context.SwmsTeam.ToListAsync();
        }

        // GET: api/SwmsTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SwmsTeam>> GetSwmsTeam(int id)
        {
            var swmsTeam = await _context.SwmsTeam.FindAsync(id);

            if (swmsTeam == null)
            {
                return NotFound();
            }

            return swmsTeam;
        }

        // PUT: api/SwmsTeams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSwmsTeam(int id, SwmsTeam swmsTeam)
        {
            if (id != swmsTeam.Id)
            {
                return BadRequest();
            }
         
            swmsTeam.DateModified = DateTime.Now;
            _context.Entry(swmsTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SwmsTeamExists(id))
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

        // POST: api/SwmsTeams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SwmsTeam>> PostSwmsTeam(SwmsTeam swmsTeam)
        {

            swmsTeam.DateModified = DateTime.Now;
            _context.SwmsTeam.Add(swmsTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSwmsTeam", new { id = swmsTeam.Id }, swmsTeam);
        }

        // DELETE: api/SwmsTeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SwmsTeam>> DeleteSwmsTeam(int id)
        {
            var swmsTeam = await _context.SwmsTeam.FindAsync(id);
            if (swmsTeam == null)
            {
                return NotFound();
            }

            _context.SwmsTeam.Remove(swmsTeam);
            await _context.SaveChangesAsync();

            return swmsTeam;
        }

        private bool SwmsTeamExists(int id)
        {
            return _context.SwmsTeam.Any(e => e.Id == id);
        }
    }
}
