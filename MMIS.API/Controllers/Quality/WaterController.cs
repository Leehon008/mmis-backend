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



    public class WaterController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public WaterController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIP
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Water>>> GetQualityWaterTreatment()
        //{
        //    return await _context.QualityWaterTreatment.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Water>>> GetQualityWaterTreatment(string Plant)
        {
            return await _context.QualityWaterTreatment.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateTime).ToListAsync();
        }

        // GET: api/PIP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Water>> GetWater(int id)
        {
            var water = await _context.QualityWaterTreatment.FindAsync(id);

            if (water == null)
            {
                return NotFound();
            }

            return water;
        }

        // PUT: api/PIP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWater(int id, Water water)
        {
            if (id != water.Id)
            {
                return BadRequest();
            }
            water.Modified = DateTime.Now;
            //_context.Entry(water).State = EntityState.Modified;
            _context.Attach(water);

            var entry = _context.Entry(water);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in water.RawWater.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityWaterTreatment.Find(water.Id)
                        .RawWater.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in water.PostSandFiltration.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityWaterTreatment.Find(water.Id)
                        .PostSandFiltration.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in water.PostChlorination.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityWaterTreatment.Find(water.Id)
                        .PostChlorination.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in water.TreatedWater.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityWaterTreatment.Find(water.Id)
                        .TreatedWater.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!WaterExists(id))
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

        // POST: api/PIP
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Water>> PostWater(Water water)
        {
            water.Created = DateTime.Now;
            water.Modified = water.Created;
            _context.QualityWaterTreatment.Add(water);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWater", new { id = water.Id }, water);
        }

        // DELETE: api/PIP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Water>> DeleteWater(int id)
        {
            var water = await _context.QualityWaterTreatment.FindAsync(id);
            if (water == null)
            {
                return NotFound();
            }

            _context.QualityWaterTreatment.Remove(water);
            await _context.SaveChangesAsync();

            return water;
        }

        private bool WaterExists(int id)
        {
            return _context.QualityWaterTreatment.Any(e => e.Id == id);
        }
    }
}
