using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class ManWorkedHoursController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        
     
        private readonly MMISDbContext _context;




        public ManWorkedHoursController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, MMISDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
     
            _context = context;
        }

        // GET: api/SHEManWorkedHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManWorkedHours>>> GetSHEManWorkedHours()
        {
            return await _context.SHEManWorkedHours.ToListAsync();
        }

        // GET: api/SHEManWorkedHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManWorkedHours>> GetSHEManWorkedHours(int id)
        {
            var manWorkedHours = await _context.SHEManWorkedHours.FindAsync(id);

            if (manWorkedHours == null)
            {
                return NotFound();
            }

            return manWorkedHours;
        }

        // PUT: api/SHEManWorkedHours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSHEManWorkedHours(int id, ManWorkedHours manWorkedHours)
        {
            if (id != manWorkedHours.Id)
            {
                return BadRequest();
            }

            manWorkedHours.ModifiedBy = User.Identity.Name;
            manWorkedHours.DateModified = DateTime.Now;
            _context.Entry(manWorkedHours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SHEManWorkedHoursExists(id))
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

        // POST: api/SHEManWorkedHours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ManWorkedHours>> PostSHEManWorkedHours(ManWorkedHours manWorkedHours)
        {
            manWorkedHours.DateCreated = DateTime.Now;
            manWorkedHours.CreatedBy = User.Identity.Name;
            _context.SHEManWorkedHours.Add(manWorkedHours);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSHEManWorkedHours", new { id = manWorkedHours.Id }, manWorkedHours);
        }

        // DELETE: api/SHEManWorkedHours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManWorkedHours>> DeleteSHEManWorkedHours(int id)
        {
            var manWorkedHours = await _context.SHEManWorkedHours.FindAsync(id);
            if (manWorkedHours == null)
            {
                return NotFound();
            }

            _context.SHEManWorkedHours.Remove(manWorkedHours);
            await _context.SaveChangesAsync();

            return manWorkedHours;
        }

        private bool SHEManWorkedHoursExists(int id)
        {
            return _context.SHEManWorkedHours.Any(e => e.Id == id);
        }
    }
}
