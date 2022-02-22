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

    public class ShelflifeScudController : ControllerBase
    {

        private readonly MMISDbContext _context;

        public ShelflifeScudController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/ShelflifeScud
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ShelflifeScud>>> GetQualityShelflifeScud()
        //{
        //    return await _context.QualityShelflifeScud.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelflifeScud>>> GetQualityShelflifeScud(string Plant)
        {
            return await _context.QualityShelflifeScud.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        // GET: api/ShelflifeScud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelflifeScud>> GetShelflifeScud(int id)
        {
            var shelflife = await _context.QualityShelflifeScud.FindAsync(id);

            if (shelflife == null)
            {
                return NotFound();
            }

            return shelflife;
        }

        // PUT: api/ShelflifeScud/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelflifeScud(int id, ShelflifeScud shelflife)
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
                    var entityEntry = _context.Entry(_context.QualityShelflifeScud.Find(shelflife.Id)
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
                if (!ShelflifeScudExists(id))
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

        // POST: api/ShelflifeScud
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShelflifeScud>> PostShelflifeScud(ShelflifeScud shelflife)
        {
            shelflife.Created = DateTime.Now;
            shelflife.Modified = DateTime.Now;
            //shelflife.Parameters.First().Day = 1;

            _context.QualityShelflifeScud.Add(shelflife);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShelflifeScud", new { id = shelflife.Id }, shelflife);
        }

        // DELETE: api/ShelflifeScud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShelflifeScud>> DeleteShelflifeScud(int id)
        {
            var shelflife = await _context.QualityShelflifeScud.FindAsync(id);
            if (shelflife == null)
            {
                return NotFound();
            }

            _context.QualityShelflifeScud.Remove(shelflife);
            await _context.SaveChangesAsync();

            return shelflife;
        }

        private bool ShelflifeScudExists(int id)
        {
            return _context.QualityShelflifeScud.Any(e => e.Id == id);
        }
    }
}
