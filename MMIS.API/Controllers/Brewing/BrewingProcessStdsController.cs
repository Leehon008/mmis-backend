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



    public class BrewingProcessStdsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingProcessStdsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingProcessTimeStds
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BrewingProcessTimeStds>>> GetBrewingBrewingProcessTimeStds()
        //{
        //    return await _context.BrewingBrewingProcessTimeStds.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrewingProcessTimeStds>>> GetBrewingBrewingProcessTimeStds(string Plant, string BrewProcessType)
        {
            return await _context.BrewingProcessTimeStds.Where(m => m.Plant.Contains(Plant) && m.BrewProcessType.Equals(BrewProcessType)).OrderByDescending(m => m.Plant).ToListAsync();
        }

        // GET: api/BrewingProcessTimeStds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrewingProcessTimeStds>> GetBrewingProcessTimeStds(int id)
        {
            var obj = await _context.BrewingProcessTimeStds.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/BrewingProcessTimeStds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewingProcessTimeStds(int id, BrewingProcessTimeStds obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }
          
            _context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewingProcessTimeStdsExists(id))
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

        // POST: api/BrewingProcessTimeStds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewingProcessTimeStds>> PostBrewingProcessTimeStds(BrewingProcessTimeStds obj)
        {
            
            _context.BrewingProcessTimeStds.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewingProcessTimeStds", new { id = obj.Id }, obj);
        }

        // DELETE: api/BrewingProcessTimeStds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrewingProcessTimeStds>> DeleteBrewingProcessTimeStds(int id)
        {
            var obj = await _context.BrewingProcessTimeStds.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.BrewingProcessTimeStds.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool BrewingProcessTimeStdsExists(int id)
        {
            return _context.BrewingProcessTimeStds.Any(e => e.Id == id);
        }
    }
}
