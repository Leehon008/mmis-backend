using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    public class BulkWaterController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BulkWaterController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BulkWater
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BulkWater>>> GetQualityBulkWater()
        //{
        //    return await _context.QualityBulkWater.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BulkWater>>> GetQualityBulkWater(string Plant)
        {
            return await _context.QualityBulkWater.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateTime).ToListAsync();
        }

        // GET: api/BulkWater/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BulkWater>> GetBulkWater(int id)
        {
            var bulkWater = await _context.QualityBulkWater.FindAsync(id);

            if (bulkWater == null)
            {
                return NotFound();
            }

            return bulkWater;
        }

        // PUT: api/BulkWater/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBulkWater(int id, BulkWater bulkWater)
        {
            if (id != bulkWater.Id)
            {
                return BadRequest();
            }
            bulkWater.Modified = DateTime.Now;

            _context.Entry(bulkWater).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BulkWaterExists(id))
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

        // POST: api/BulkWater
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BulkWater>> PostBulkWater(BulkWater bulkWater)
        {
            bulkWater.Created = DateTime.Now;
            bulkWater.Modified = DateTime.Now;
            _context.QualityBulkWater.Add(bulkWater);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBulkWater", new { id = bulkWater.Id }, bulkWater);
        }

        // DELETE: api/BulkWater/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BulkWater>> DeleteBulkWater(int id)
        {
            var bulkWater = await _context.QualityBulkWater.FindAsync(id);
            if (bulkWater == null)
            {
                return NotFound();
            }

            _context.QualityBulkWater.Remove(bulkWater);
            await _context.SaveChangesAsync();

            return bulkWater;
        }

        private bool BulkWaterExists(int id)
        {
            return _context.QualityBulkWater.Any(e => e.Id == id);
        }
    }
}
