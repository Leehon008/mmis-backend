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

    public class FermentationScudsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public FermentationScudsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/FermentationScuds
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FermentationScud>>> GetQualityFermentationScud()
        //{
        //    return await _context.QualityFermentationScud.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FermentationScud>>> GetQualityFermentationScud(string Plant)
        {
            return await _context.QualityFermentationScud.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/FermentationScuds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FermentationScud>> GetFermentationScud(int id)
        {
            var FermentationScud = await _context.QualityFermentationScud.FindAsync(id);

            if (FermentationScud == null)
            {
                return NotFound();
            }

            return FermentationScud;
        }

        // PUT: api/FermentationScuds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFermentationScud(int id, FermentationScud FermentationScud)
        {
            if (id != FermentationScud.Id)
            {
                return BadRequest();
            }

            FermentationScud.Modified = DateTime.Now;
            //_context.Entry(FermentationScud).State = EntityState.Modified;
            _context.Attach(FermentationScud);

            var entry = _context.Entry(FermentationScud);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //_context.Entry(FermentationScud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermentationScudExists(id))
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

        // POST: api/FermentationScuds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FermentationScud>> PostFermentationScud(FermentationScud FermentationScud)
        {
            FermentationScud.Created = DateTime.Now;
            FermentationScud.Modified = FermentationScud.Created;
            _context.QualityFermentationScud.Add(FermentationScud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFermentationScud", new { id = FermentationScud.Id }, FermentationScud);
        }

        // DELETE: api/FermentationScuds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FermentationScud>> DeleteFermentationScud(int id)
        {
            var FermentationScud = await _context.QualityFermentationScud.FindAsync(id);
            if (FermentationScud == null)
            {
                return NotFound();
            }

            _context.QualityFermentationScud.Remove(FermentationScud);
            await _context.SaveChangesAsync();

            return FermentationScud;
        }

        private bool FermentationScudExists(int id)
        {
            return _context.QualityFermentationScud.Any(e => e.Id == id);
        }
    }
}
