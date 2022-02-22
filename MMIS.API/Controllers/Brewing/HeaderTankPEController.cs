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



    public class HeaderTankPEController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public HeaderTankPEController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/HeaderTankPE
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<HeaderTankPE>>> GetBrewingHeaderTankPE()
        //{
        //    return await _context.BrewingHeaderTankPE.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeaderTankPE>>> GetBrewingHeaderTankPE(string Plant)
        {
            return await _context.BrewingHeaderTankPE.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/HeaderTankPE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeaderTankPE>> GetHeaderTankPE(int id)
        {
            var headerTankPE = await _context.BrewingHeaderTankPE.FindAsync(id);

            if (headerTankPE == null)
            {
                return NotFound();
            }

            return headerTankPE;
        }

        // PUT: api/HeaderTankPE/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeaderTankPE(int id, HeaderTankPE headerTankPE)
        {
            if (id != headerTankPE.Id)
            {
                return BadRequest();
            }
            headerTankPE.Modified = DateTime.Now;
            _context.Entry(headerTankPE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderTankPEExists(id))
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

        // POST: api/HeaderTankPE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HeaderTankPE>> PostHeaderTankPE(HeaderTankPE headerTankPE)
        {
            headerTankPE.Created = DateTime.Now;
            headerTankPE.Modified = DateTime.Now;
            _context.BrewingHeaderTankPE.Add(headerTankPE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeaderTankPE", new { id = headerTankPE.Id }, headerTankPE);
        }

        // DELETE: api/HeaderTankPE/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HeaderTankPE>> DeleteHeaderTankPE(int id)
        {
            var headerTankPE = await _context.BrewingHeaderTankPE.FindAsync(id);
            if (headerTankPE == null)
            {
                return NotFound();
            }

            _context.BrewingHeaderTankPE.Remove(headerTankPE);
            await _context.SaveChangesAsync();

            return headerTankPE;
        }

        private bool HeaderTankPEExists(int id)
        {
            return _context.BrewingHeaderTankPE.Any(e => e.Id == id);
        }
    }
}
