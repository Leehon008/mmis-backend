using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using MMIS.DomainLayer.Entities.Shifts;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Microsoft.AspNetCore.Authorization.Authorize]
    public class PackagingShiftTeamsController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public PackagingShiftTeamsController(MMISDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: api/ShiftTeamss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftTeams>>> GetShiftTeams()
        {
            return await _context.ShiftTeams.ToListAsync();
        }

        // GET: api/ShiftTeamss/packaging/p080/Bhora
        [HttpGet("{module}/{Plant}/{shiftName}")]
        public async Task<ActionResult<IEnumerable<ShiftTeams>>> GetShiftTeams(string shiftName,string Plant,string module)
        {
            var ShiftTeams = await _context.ShiftTeams.Where(x => x.ShiftName.Equals(shiftName) && x.Plant.Equals(Plant) && x.Module.Equals(module) && x.Active == true).ToListAsync() ;

            if (ShiftTeams == null)
            {
                return NotFound();
            }

            return ShiftTeams;
        }

        // GET: api/ShiftTeamss/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShiftTeams>> GetShiftTeams(int id)
        {
            var ShiftTeams = await _context.ShiftTeams.FindAsync(id);

            if (ShiftTeams == null)
            {
                return NotFound();
            }

            return ShiftTeams;
        }

        // PUT: api/ShiftTeamss/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftTeams(int id, ShiftTeams ShiftTeams)
        {
            if (id != ShiftTeams.Id)
            {
                return BadRequest();
            }

            ShiftTeams.DateModified = DateTime.Now;
            ShiftTeams.ModifiedBy = User.Identity.Name;

            _context.Entry(ShiftTeams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftTeamsExists(id))
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

        // POST: api/ShiftTeamss
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShiftTeams>> PostShiftTeams(List<ShiftTeams> ShiftTeams)
        {
            foreach (var ShiftTeamsData in ShiftTeams)
            {
                ShiftTeamsData.DateCreated = DateTime.Now;
                ShiftTeamsData.CreatedBy = User.Identity.Name;
                ShiftTeamsData.Active = true;
                _context.ShiftTeams.Add(ShiftTeamsData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetShiftTeams", new { ShiftTeams });
 
        }

        // DELETE: api/ShiftTeamss/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShiftTeams>> DeleteShiftTeams(int id)
        {
            var ShiftTeams = await _context.ShiftTeams.FindAsync(id);
            if (ShiftTeams == null)
            {
                return NotFound();
            }

            _context.ShiftTeams.Remove(ShiftTeams);
            await _context.SaveChangesAsync();

            return ShiftTeams;
        }

        private bool ShiftTeamsExists(int id)
        {
            return _context.ShiftTeams.Any(e => e.Id == id);
        }
    }
}
