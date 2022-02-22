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
    public class MaltAdditionController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaltAdditionController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltAddition
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaltAddition>>> GetBrewingMaltAddition()
        //{
        //    return await _context.BrewingMaltAddition.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltAddition>>> GetBrewingMaltAddition(string Plant)
        {
            return await _context.BrewingMaltAddition.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.AdditionTime).ToListAsync();
        }

        // GET: api/MaltAddition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltAddition>> GetMaltAddition(int id)
        {
            var malt = await _context.BrewingMaltAddition.FindAsync(id);

            if (malt == null)
            {
                return NotFound();
            }

            return malt;
        }

        // PUT: api/MaltAddition/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltAddition(int id, MaltAddition malt)
        {
            if (id != malt.Id)
            {
                return BadRequest();
            }

            malt.Modified = DateTime.Now;
            _context.Entry(malt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltAdditionExists(id))
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

        // POST: api/MaltAddition
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltAddition>> PostMaltAddition(MaltAddition malt)
        {
            malt.Created = DateTime.Now;
            malt.Modified = DateTime.Now;
            _context.BrewingMaltAddition.Add(malt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltAddition", new { id = malt.Id }, malt);
        }

        // DELETE: api/MaltAddition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltAddition>> DeleteMaltAddition(int id)
        {
            var malt = await _context.BrewingMaltAddition.FindAsync(id);
            if (malt == null)
            {
                return NotFound();
            }

            _context.BrewingMaltAddition.Remove(malt);
            await _context.SaveChangesAsync();

            return malt;
        }

        private bool MaltAdditionExists(int id)
        {
            return _context.BrewingMaltAddition.Any(e => e.Id == id);
        }
    }
}
