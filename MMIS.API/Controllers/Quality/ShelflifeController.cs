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

    public class ShelflifeController : ControllerBase
    {

        private readonly MMISDbContext _context;

        public ShelflifeController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Shelflife
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Shelflife>>> GetQualityShelflife()
        //{
        //    return await _context.QualityShelflife.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelflife>>> GetQualityShelflife(string Plant)
        {
            return await _context.QualityShelflife.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        // GET: api/Shelflife/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelflife>> GetShelflife(int id)
        {
            var shelflife = await _context.QualityShelflife.FindAsync(id);

            if (shelflife == null)
            {
                return NotFound();
            }

            return shelflife;
        }

        // PUT: api/Shelflife/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelflife(int id, Shelflife shelflife)
        {
            if (id != shelflife.Id)
            {
                return BadRequest();
            }

            shelflife.Modified = DateTime.Now;

            //_context.Entry(shelflife).State = EntityState.Modified;
            _context.Attach(shelflife);

            var entry = _context.Entry(shelflife);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            entry.Property(e => e.BatchNumber).IsModified = false;

            foreach (var navigationProperty in shelflife.Parameters.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityShelflife.Find(shelflife.Id)
                        .Parameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelflifeExists(id))
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

        // POST: api/Shelflife
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shelflife>> PostShelflife(Shelflife shelflife)
        {
            shelflife.Created = DateTime.Now;
            shelflife.Modified = DateTime.Now;
            shelflife.Parameters.First().Day = 1;

            _context.QualityShelflife.Add(shelflife);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShelflife", new { id = shelflife.Id }, shelflife);
        }

        // DELETE: api/Shelflife/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shelflife>> DeleteShelflife(int id)
        {
            var shelflife = await _context.QualityShelflife.FindAsync(id);
            if (shelflife == null)
            {
                return NotFound();
            }

            _context.QualityShelflife.Remove(shelflife);
            await _context.SaveChangesAsync();

            return shelflife;
        }

        private bool ShelflifeExists(int id)
        {
            return _context.QualityShelflife.Any(e => e.Id == id);
        }
    }
}
