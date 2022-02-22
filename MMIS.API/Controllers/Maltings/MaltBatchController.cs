using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Maltings.Entities;

namespace MMIS.API.Controllers.Maltings
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class MaltBatchController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaltBatchController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltBatch
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaltBatch>>> GetMaltBatchingMaltBatch()
        //{
        //    return await _context.MaltingsMaltBatch.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltBatch>>> GetMaltBatchingMaltBatch(string Plant)
        {
            return await _context.MaltingsMaltBatch.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/MaltBatch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltBatch>> GetMaltBatch(int id)
        {
            var obj = await _context.MaltingsMaltBatch.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/MaltBatch/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltBatch(int id, MaltBatch obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            //_context.Entry(temp).State = EntityState.Modified;

            obj.Modified = DateTime.Now;
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Stocks.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MaltingsMaltBatch.Find(obj.Id)
                        .Stocks.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!MaltBatchExists(id))
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

        // POST: api/MaltBatch
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltBatch>> PostMaltBatch(MaltBatch obj)
        {
            obj.Modified = DateTime.Now;
            obj.Created = DateTime.Now;
            _context.MaltingsMaltBatch.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltBatch", new { id = obj.Id }, obj);
        }

        // DELETE: api/MaltBatch/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltBatch>> DeleteMaltBatch(int id)
        {
            var obj = await _context.MaltingsMaltBatch.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            //_context.MaltingsMaltBatch.Remove(obj);
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Deleted;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Stocks)
            {
                var entityEntry = _context.Entry(_context.MaltingsMaltBatch.Find(obj.Id)
                    .Stocks.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();

            return obj;
        }

        private bool MaltBatchExists(int id)
        {
            return _context.MaltingsMaltBatch.Any(e => e.Id == id);
        }
    }
}
