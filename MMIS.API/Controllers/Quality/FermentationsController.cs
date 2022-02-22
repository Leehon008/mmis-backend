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

    public class FermentationsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public FermentationsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Fermentations
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Fermentation>>> GetQualityFermentation()
        //{
        //    return await _context.QualityFermentation.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fermentation>>> GetQualityFermentation(string Plant)
        {
            return await _context.QualityFermentation.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        // GET: api/Fermentations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fermentation>> GetFermentation(int id)
        {
            var fermentation = await _context.QualityFermentation.FindAsync(id);

            if (fermentation == null)
            {
                return NotFound();
            }

            return fermentation;
        }

        // PUT: api/Fermentations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFermentation(int id, Fermentation fermentation)
        {
            if (id != fermentation.Id)
            {
                return BadRequest();
            }

            fermentation.Modified = DateTime.Now;
            //_context.Entry(fermentation).State = EntityState.Modified;
            _context.Attach(fermentation);

            var entry = _context.Entry(fermentation);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //entry.Property(e => e.MaltBatch).IsModified = false;
            //entry.Property(e => e.YeastBatch).IsModified = false;
            //entry.Property(e => e.BrewNo).IsModified = false;
            //entry.Property(e => e.BrixAtWort).IsModified = false;

            foreach (var navigationProperty in fermentation.Parameters.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityFermentation.Find(fermentation.Id)
                        .Parameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in fermentation.ScudParameters.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityFermentation.Find(fermentation.Id)
                        .ScudParameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            //_context.Entry(fermentation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermentationExists(id))
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

        // POST: api/Fermentations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fermentation>> PostFermentation(Fermentation fermentation)
        {
            fermentation.Created = DateTime.Now;
            fermentation.Modified = fermentation.Created;
            _context.QualityFermentation.Add(fermentation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFermentation", new { id = fermentation.Id }, fermentation);
        }

        // DELETE: api/Fermentations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fermentation>> DeleteFermentation(int id)
        {
            var fermentation = await _context.QualityFermentation.FindAsync(id);
            if (fermentation == null)
            {
                return NotFound();
            }

            _context.Attach(fermentation);

            var entry = _context.Entry(fermentation);
            entry.State = EntityState.Deleted;

            foreach (var navigationProperty in fermentation.Parameters)
            {
                var entityEntry = _context.Entry(_context.QualityFermentation.Find(fermentation.Id)
                    .Parameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in fermentation.ScudParameters.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.QualityFermentation.Find(fermentation.Id)
                    .ScudParameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            //            _context.QualityFermentation.Remove(fermentation);
            await _context.SaveChangesAsync();

            return fermentation;
        }

        private bool FermentationExists(int id)
        {
            return _context.QualityFermentation.Any(e => e.Id == id);
        }
    }
}
