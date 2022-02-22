using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class VUsageController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public VUsageController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/VUsage
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VUsage>>> GetQualityVUsage()
        //{
        //    return await _context.QualityVUsage.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VUsage>>> GetQualityVUsage(string Plant)
        {
            return await _context.QualityVUsage.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.LastCIP).ToListAsync();
        }

        // GET: api/VUsage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VUsage>> GetVUsage(int id)
        {
            var vUsage = await _context.QualityVUsage.FindAsync(id);

            if (vUsage == null)
            {
                return NotFound();
            }

            return vUsage;
        }

        // PUT: api/VUsage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVUsage(int id, VUsage vUsage)
        {
            if (id != vUsage.Id)
            {
                return BadRequest();
            }

            vUsage.Modified = DateTime.Now;
            _context.Entry(vUsage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VUsageExists(id))
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

        // POST: api/VUsage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VUsage>> PostVUsage(VUsage vUsage)
        {
            vUsage.Created = DateTime.Now;
            vUsage.Modified = DateTime.Now;
            _context.QualityVUsage.Add(vUsage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVUsage", new { id = vUsage.Id }, vUsage);
        }

        // DELETE: api/VUsage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VUsage>> DeleteVUsage(int id)
        {
            var vUsage = await _context.QualityVUsage.FindAsync(id);
            if (vUsage == null)
            {
                return NotFound();
            }

            _context.QualityVUsage.Remove(vUsage);
            await _context.SaveChangesAsync();

            return vUsage;
        }

        private bool VUsageExists(int id)
        {
            return _context.QualityVUsage.Any(e => e.Id == id);
        }
    }
}
