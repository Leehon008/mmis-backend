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



    public class BrewingFermentationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingFermentationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingFermentation
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BrewingFermentation>>> GetBrewingFermentation()
        //{
        //    return await _context.BrewingFermentation.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrewingFermentation>>> GetBrewingFermentation(string Plant)
        {
            return await _context.BrewingFermentation.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingFermentation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrewingFermentation>> GetFermentation(int id)
        {
            var fermentation = await _context.BrewingFermentation.FindAsync(id);

            if (fermentation == null)
            {
                return NotFound();
            }

            return fermentation;
        }

        // PUT: api/BrewingFermentation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFermentation(int id, BrewingFermentation fermentation)
        {
            if (id != fermentation.Id)
            {
                return BadRequest();
            }
            fermentation.Modified = DateTime.Now;
            _context.Entry(fermentation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermentationExists(id))
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

        // POST: api/BrewingFermentation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewingFermentation>> PostFermentation(BrewingFermentation fermentation)
        {
            fermentation.Created = DateTime.Now;
            fermentation.Modified = DateTime.Now;
            _context.BrewingFermentation.Add(fermentation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFermentation", new { id = fermentation.Id }, fermentation);
        }

        // DELETE: api/BrewingFermentation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrewingFermentation>> DeleteFermentation(int id)
        {
            var fermentation = await _context.BrewingFermentation.FindAsync(id);
            if (fermentation == null)
            {
                return NotFound();
            }

            _context.BrewingFermentation.Remove(fermentation);
            await _context.SaveChangesAsync();

            return fermentation;
        }

        private bool FermentationExists(int id)
        {
            return _context.BrewingFermentation.Any(e => e.Id == id);
        }
    }
}
