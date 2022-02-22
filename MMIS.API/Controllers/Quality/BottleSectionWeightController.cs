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

    public class BottleSectionWeightController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BottleSectionWeightController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BottleSectionWeight
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BottleSectionWeight>>> GetQualityBottleSectionWeight()
        //{
        //    return await _context.QualityBottleSectionWeight.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BottleSectionWeight>>> GetQualityBottleSectionWeight(string Plant)
        {
            return await _context.QualityBottleSectionWeight.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BottleSectionWeight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BottleSectionWeight>> GetBottleSectionWeight(int id)
        {
            var obj = await _context.QualityBottleSectionWeight.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/BottleSectionWeight/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBottleSectionWeight(int id, BottleSectionWeight obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            obj.Modified = DateTime.Now;
            //_context.Entry(obj).State = EntityState.Modified;
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;


            foreach (var navigationProperty in obj.BSWItems.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityBottleSectionWeight.Find(obj.Id)
                        .BSWItems.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            //_context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BottleSectionWeightExists(id))
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

        // POST: api/BottleSectionWeight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BottleSectionWeight>> PostBottleSectionWeight(BottleSectionWeight obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityBottleSectionWeight.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBottleSectionWeight", new { id = obj.Id }, obj);
        }

        // DELETE: api/BottleSectionWeight/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BottleSectionWeight>> DeleteBottleSectionWeight(int id)
        {
            var obj = await _context.QualityBottleSectionWeight.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityBottleSectionWeight.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool BottleSectionWeightExists(int id)
        {
            return _context.QualityBottleSectionWeight.Any(e => e.Id == id);
        }
    }
}
