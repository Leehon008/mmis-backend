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

    public class PlantAccessController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PlantAccessController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantAccess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantAccess>>> GetPlantAccess()
        {
            return await _context.PlantAccess.ToListAsync();
        }

        // GET: api/PlantAccess/5
        [HttpGet("{username}")]
        public async Task<ActionResult<List<PlantAccess>>> GetPlantAccess(string username)
        {
            var plantAccess =  await _context.PlantAccess.Where(x=>x.Username == username).ToListAsync();

            if (plantAccess == null)
            {
                return NotFound();
            }

            return plantAccess;
        }

        // PUT: api/PlantAccess/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantAccess(int id, PlantAccess plantAccess)
        {
            if (id != plantAccess.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantAccessExists(id))
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

        // POST: api/PlantAccess
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlantAccess>> PostPlantAccess(PlantAccess plantAccess)
        {
            _context.PlantAccess.Add(plantAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantAccess", new { id = plantAccess.Id }, plantAccess);
        }

        // DELETE: api/PlantAccess/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantAccess>> DeletePlantAccess(int id)
        {
            var plantAccess = await _context.PlantAccess.FindAsync(id);
            if (plantAccess == null)
            {
                return NotFound();
            }

            _context.PlantAccess.Remove(plantAccess);
            await _context.SaveChangesAsync();

            return plantAccess;
        }

        private bool PlantAccessExists(int id)
        {
            return _context.PlantAccess.Any(e => e.Id == id);
        }
    }
}
