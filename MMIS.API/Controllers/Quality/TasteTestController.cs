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



    public class TasteTestController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public TasteTestController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIP
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TasteTest>>> GetQualityTasteTest()
        //{
        //    return await _context.QualityTasteTest.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasteTest>>> GetQualityTasteTest(string Plant)
        {
            return await _context.QualityTasteTest.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.TasteDate).ToListAsync();
        }

        // GET: api/PIP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TasteTest>> GetTasteTest(int id)
        {
            var tt = await _context.QualityTasteTest.FindAsync(id);

            if (tt == null)
            {
                return NotFound();
            }

            return tt;
        }

        // PUT: api/PIP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasteTest(int id, TasteTest tt)
        {
            if (id != tt.Id)
            {
                return BadRequest();
            }
            tt.Modified = DateTime.Now;
            //_context.Entry(tt).State = EntityState.Modified;
            _context.Attach(tt);

            var entry = _context.Entry(tt);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in tt.Testers.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityTasteTest.Find(tt.Id)
                        .Testers.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!TasteTestExists(id))
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
        public async Task<ActionResult<TasteTest>> PostTasteTest(TasteTest tt)
        {
            tt.Created = DateTime.Now;
            tt.Modified = tt.Created;
            _context.QualityTasteTest.Add(tt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasteTest", new { id = tt.Id }, tt);
        }

        // DELETE: api/PIP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TasteTest>> DeleteTasteTest(int id)
        {
            var tt = await _context.QualityTasteTest.FindAsync(id);
            if (tt == null)
            {
                return NotFound();
            }

            _context.QualityTasteTest.Remove(tt);
            await _context.SaveChangesAsync();

            return tt;
        }

        private bool TasteTestExists(int id)
        {
            return _context.QualityTasteTest.Any(e => e.Id == id);
        }
    }
}
