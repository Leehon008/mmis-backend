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



    public class HeaderTankController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public HeaderTankController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/HeaderTank
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<HeaderTank>>> GetBrewingHeaderTank()
        //{
        //    return await _context.BrewingHeaderTank.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeaderTank>>> GetBrewingHeaderTank(string Plant)
        {
            return await _context.BrewingHeaderTank.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/HeaderTank/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeaderTank>> GetHeaderTank(int id)
        {
            var headerTank = await _context.BrewingHeaderTank.FindAsync(id);

            if (headerTank == null)
            {
                return NotFound();
            }

            return headerTank;
        }

        // PUT: api/HeaderTank/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeaderTank(int id, HeaderTank headerTank)
        {
            if (id != headerTank.Id)
            {
                return BadRequest();
            }
            headerTank.Modified = DateTime.Now;
            _context.Entry(headerTank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderTankExists(id))
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

        // POST: api/HeaderTank
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HeaderTank>> PostHeaderTank(HeaderTank headerTank)
        {
            headerTank.Created = DateTime.Now;
            headerTank.Modified = DateTime.Now;
            _context.BrewingHeaderTank.Add(headerTank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeaderTank", new { id = headerTank.Id }, headerTank);
        }

        // DELETE: api/HeaderTank/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HeaderTank>> DeleteHeaderTank(int id)
        {
            var headerTank = await _context.BrewingHeaderTank.FindAsync(id);
            if (headerTank == null)
            {
                return NotFound();
            }

            _context.BrewingHeaderTank.Remove(headerTank);
            await _context.SaveChangesAsync();

            return headerTank;
        }

        private bool HeaderTankExists(int id)
        {
            return _context.BrewingHeaderTank.Any(e => e.Id == id);
        }
    }
}
