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

    public class FermentationSuperController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public FermentationSuperController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/FermentationSupers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FermentationSuper>>> GetQualityFermentationSuper()
        //{
        //    return await _context.QualityFermentationSuper.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FermentationSuper>>> GetQualityFermentationSuper(string Plant)
        {
            return await _context.QualityFermentationSuper.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/FermentationSupers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FermentationSuper>> GetFermentationSuper(int id)
        {
            var FermentationSuper = await _context.QualityFermentationSuper.FindAsync(id);

            if (FermentationSuper == null)
            {
                return NotFound();
            }

            return FermentationSuper;
        }

        // PUT: api/FermentationSupers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFermentationSuper(int id, FermentationSuper FermentationSuper)
        {
            if (id != FermentationSuper.Id)
            {
                return BadRequest();
            }

            FermentationSuper.Modified = DateTime.Now;
            //_context.Entry(FermentationSuper).State = EntityState.Modified;
            _context.Attach(FermentationSuper);

            var entry = _context.Entry(FermentationSuper);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //_context.Entry(FermentationSuper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermentationSuperExists(id))
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

        // POST: api/FermentationSupers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FermentationSuper>> PostFermentationSuper(FermentationSuper FermentationSuper)
        {
            FermentationSuper.Created = DateTime.Now;
            FermentationSuper.Modified = FermentationSuper.Created;
            _context.QualityFermentationSuper.Add(FermentationSuper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFermentationSuper", new { id = FermentationSuper.Id }, FermentationSuper);
        }

        // DELETE: api/FermentationSupers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FermentationSuper>> DeleteFermentationSuper(int id)
        {
            var FermentationSuper = await _context.QualityFermentationSuper.FindAsync(id);
            if (FermentationSuper == null)
            {
                return NotFound();
            }

            _context.QualityFermentationSuper.Remove(FermentationSuper);
            await _context.SaveChangesAsync();

            return FermentationSuper;
        }

        private bool FermentationSuperExists(int id)
        {
            return _context.QualityFermentationSuper.Any(e => e.Id == id);
        }
    }
}
