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



    public class BrewingFermentationPEController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewingFermentationPEController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BrewingFermentationPE
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FermentationPE>>> GetBrewingFermentationPE()
        //{
        //    return await _context.BrewingFermentationPE.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FermentationPE>>> GetBrewingFermentationPE(string Plant)
        {
            return await _context.BrewingFermentationPE.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BrewingFermentationPE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FermentationPE>> GetFermentationPE(int id)
        {
            var fermentationPE = await _context.BrewingFermentationPE.FindAsync(id);

            if (fermentationPE == null)
            {
                return NotFound();
            }

            return fermentationPE;
        }

        // PUT: api/BrewingFermentationPE/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFermentationPE(int id, FermentationPE fermentationPE)
        {
            if (id != fermentationPE.Id)
            {
                return BadRequest();
            }
            fermentationPE.Modified = DateTime.Now;
            _context.Entry(fermentationPE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermentationPEExists(id))
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

        // POST: api/BrewingFermentationPE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FermentationPE>> PostFermentationPE(FermentationPE fermentationPE)
        {
            fermentationPE.Created = DateTime.Now;
            fermentationPE.Modified = DateTime.Now;
            _context.BrewingFermentationPE.Add(fermentationPE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFermentationPE", new { id = fermentationPE.Id }, fermentationPE);
        }

        // DELETE: api/BrewingFermentationPE/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FermentationPE>> DeleteFermentationPE(int id)
        {
            var fermentationPE = await _context.BrewingFermentationPE.FindAsync(id);
            if (fermentationPE == null)
            {
                return NotFound();
            }

            _context.BrewingFermentationPE.Remove(fermentationPE);
            await _context.SaveChangesAsync();

            return fermentationPE;
        }

        private bool FermentationPEExists(int id)
        {
            return _context.BrewingFermentationPE.Any(e => e.Id == id);
        }
    }
}
