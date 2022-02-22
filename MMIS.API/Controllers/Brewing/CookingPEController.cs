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



    public class CookingPEController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CookingPEController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CookingPE
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CookingPE>>> GetBrewingCookingPE()
        //{
        //    return await _context.BrewingCookingPE.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookingPE>>> GetBrewingCookingPE(string Plant)
        {
            return await _context.BrewingCookingPE.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/CookingPE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookingPE>> GetCookingPE(int id)
        {
            var cookingPE = await _context.BrewingCookingPE.FindAsync(id);

            if (cookingPE == null)
            {
                return NotFound();
            }

            return cookingPE;
        }

        // PUT: api/CookingPE/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookingPE(int id, CookingPE cookingPE)
        {
            if (id != cookingPE.Id)
            {
                return BadRequest();
            }
            cookingPE.Modified = DateTime.Now;
            _context.Entry(cookingPE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookingPEExists(id))
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

        // POST: api/CookingPE
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CookingPE>> PostCookingPE(CookingPE cookingPE)
        {
            cookingPE.Created = DateTime.Now;
            cookingPE.Modified = DateTime.Now;
            _context.BrewingCookingPE.Add(cookingPE);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookingPE", new { id = cookingPE.Id }, cookingPE);
        }

        // DELETE: api/CookingPE/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CookingPE>> DeleteCookingPE(int id)
        {
            var cookingPE = await _context.BrewingCookingPE.FindAsync(id);
            if (cookingPE == null)
            {
                return NotFound();
            }

            _context.BrewingCookingPE.Remove(cookingPE);
            await _context.SaveChangesAsync();

            return cookingPE;
        }

        private bool CookingPEExists(int id)
        {
            return _context.BrewingCookingPE.Any(e => e.Id == id);
        }
    }
}
