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

    public class BlownBottlesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BlownBottlesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/BlownBottles
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BlownBottles>>> GetQualityBlownBottles()
        //{
        //    return await _context.QualityBlownBottles.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlownBottles>>> GetQualityBlownBottles(string Plant)
        {
            return await _context.QualityBlownBottles.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/BlownBottles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlownBottles>> GetBlownBottles(int id)
        {
            var obj = await _context.QualityBlownBottles.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/BlownBottles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlownBottles(int id, BlownBottles obj)
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


            foreach (var navigationProperty in obj.BBDimensions.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityBlownBottles.Find(obj.Id)
                        .BBDimensions.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!BlownBottlesExists(id))
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

        // POST: api/BlownBottles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BlownBottles>> PostBlownBottles(BlownBottles obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityBlownBottles.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlownBottles", new { id = obj.Id }, obj);
        }

        // DELETE: api/BlownBottles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlownBottles>> DeleteBlownBottles(int id)
        {
            var obj = await _context.QualityBlownBottles.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityBlownBottles.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool BlownBottlesExists(int id)
        {
            return _context.QualityBlownBottles.Any(e => e.Id == id);
        }
    }
}
