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



    public class CookingController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CookingController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Cooking
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cooking>>> GetBrewingCooking()
        //{
        //    return await _context.BrewingCooking.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cooking>>> GetBrewingCooking(string Plant)
        {
            return await _context.BrewingCooking.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Cooking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cooking>> GetCooking(int id)
        {
            var cooking = await _context.BrewingCooking.FindAsync(id);

            if (cooking == null)
            {
                return NotFound();
            }

            return cooking;
        }

        // PUT: api/Cooking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCooking(int id, Cooking cooking)
        {
            if (id != cooking.Id)
            {
                return BadRequest();
            }
            cooking.Modified = DateTime.Now;
            _context.Entry(cooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookingExists(id))
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

        // POST: api/Cooking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cooking>> PostCooking(Cooking cooking)
        {
            cooking.Created = DateTime.Now;
            cooking.Modified = DateTime.Now;
            _context.BrewingCooking.Add(cooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCooking", new { id = cooking.Id }, cooking);
        }

        // DELETE: api/Cooking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cooking>> DeleteCooking(int id)
        {
            var cooking = await _context.BrewingCooking.FindAsync(id);
            if (cooking == null)
            {
                return NotFound();
            }

            _context.BrewingCooking.Remove(cooking);
            await _context.SaveChangesAsync();

            return cooking;
        }

        private bool CookingExists(int id)
        {
            return _context.BrewingCooking.Any(e => e.Id == id);
        }
    }
}
